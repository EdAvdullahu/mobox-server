using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using UserAPI.DbContexts;
using UserAPI.Models;
using UserAPI.Models.Dto;
using UserAPI.RabbitMq.Models;
using UserAPI.RabbitMq.Sender;
using UserAPI.Repository.Interface;
using UserAPI.Services.Interfaces;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly IEmailSender _emailService;
        private readonly ApplicationDbContext _context;
        private readonly IRabbitMqSender _rabbitMqSender;
        public UserRepository(IUserService userService,IImageService image, ApplicationDbContext context, IEmailSender emailService, IRabbitMqSender sender)
        {
            _userService = userService;
            _context = context;
            _imageService = image;
            _emailService = emailService;
            _rabbitMqSender = sender;
        }
        public async Task<LoginResponse> AuthorizeUser(UserLogin userLogin, HttpResponse response)
        {
            User user = await _context.Users.Where(u => u.Username == userLogin.UserName || u.Email == userLogin.UserName).FirstOrDefaultAsync();
            if(user == null)
            {
                return new LoginResponse()
                {
                    Authorized = false,
                };
            }

            if (!_userService.VerifyPasswordHash(userLogin.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new LoginResponse()
                {
                    Authorized = false,
                };
            }

            string token = _userService.CreateToken(user);

            var refreshToken = _userService.GenerateRefreshToken();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires
            };
            response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            user.RefreshToken = refreshToken.Token;
            user.TokenCreated = refreshToken.Created;
            user.TokenExpires = refreshToken.Expires;
            _context.Users.Update(user);

            return new LoginResponse
            {
                Authorized = true,
                Token = token,
                Id = user.Id,
                Role = user.Role,
                RefreshToken = refreshToken.Token,
                Username = user.Username
            };
        }

        public async Task<LoginResponse> RefreshToken(LoginResponse loginResponse, string refreshToken, HttpResponse response)
        {
            User user  = _context.Users.Where(u => u.Id == loginResponse.Id).FirstOrDefault();

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return new LoginResponse()
                {
                    Authorized = false,
                };
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return new LoginResponse()
                {
                    Authorized = false,
                };
            }

            string token = _userService.CreateToken(user);
            var newRefreshToken = _userService.GenerateRefreshToken();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;

            return new LoginResponse()
            {
                Authorized = true,
                Token = token,
                Id = user.Id,
                Role = user.Role,
                RefreshToken = newRefreshToken.Token
            };
        }

        public async Task<SignUpResponse> SignUpUser(UserSignUp userSignUp)
        {
            bool user = await _context.Users.AnyAsync(u => u.Email == userSignUp.Email || u.Username == userSignUp.UserName);
            if (user)
            {
                return new SignUpResponse()
                {
                    Success = false,
                    Message = "Email or username already exists!"
                };
            }

            _userService.CreatePasswordHash(userSignUp.Password.ToString(),
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            ImageUploadResult iamgeUrl = await _imageService.AddImageAsync(userSignUp.Image);

            string verificationToken = _userService.CreateRandomToken();

            User newUser = new User()
            {
                Email = userSignUp.Email,
                Username = userSignUp.UserName,
                Name = userSignUp.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Image = iamgeUrl.Url+"",
                Role = "Listener",
                VerificationToken = verificationToken,
            };
            EmailHeader email = new EmailHeader
            {
                Email = userSignUp.Email,
                Subject = "Verify your email",
                Message = verificationToken,
                UserId = newUser.Id
            };
            _emailService.SendEmail(email, "confirm");
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return new SignUpResponse { Success = true, Message = "User created successfully" };
        }

        public async Task<bool> VerifyEmail(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);
            if (user == null)
            {
                return false;
            }

            user.VerifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            NewUserHeader newUser = new NewUserHeader
            {
                UserId = user.Id,
                Username = user.Username,
                Image = user.Image,
                Type = "Listener"
            };
            _rabbitMqSender.SendMessage(newUser, "NewUser");
            return true;
        }

        public async Task<bool> ForgotPassword(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return false;
            }

            user.PasswordResetToken = _userService.CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ResetPassword(NewPasswordRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);
            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return false;
            }

            _userService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> CreateArtist(Guid UserId)
        {
            User user = await _context.Users.Where(u => u.Id == UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            user.Role = "Artist";
            await _context.SaveChangesAsync();
            NewUserHeader newUser = new NewUserHeader
            {
                UserId = user.Id,
                Username = user.Username,
                Image = user.Image,
                Type = "Artist"
            };
            _rabbitMqSender.SendMessage(newUser, "NewUser");
            return true;
        }
    }
}
