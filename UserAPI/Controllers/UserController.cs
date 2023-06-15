using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models.Dto;
using UserAPI.RabbitMq.Models;
using UserAPI.RabbitMq.Sender;
using UserAPI.Repository.Interface;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ResponseDto _response;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new ResponseDto();
        }

        [HttpPost("login")]
        public async Task<object> Login(UserLogin user)
        {
            try
            {
                LoginResponse result = await _userRepository.AuthorizeUser(user, Response);
                if (!result.Authorized)
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Invalid Username or Password";
                }
                else
                {
                    _response.IsSuccess = true;
                    _response.Result = result;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("signup")]
        public async Task<object> Register([FromForm] UserSignUp user)
        {
            try
            {
                SignUpResponse result = await _userRepository.SignUpUser(user);
                _response.IsSuccess = result.Success;
                _response.DisplayMessage = result.Message;
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("refresh-token")]
        public async Task<object> RefreshToken(LoginResponse user)
        {
            try
            {
                var refreshToken = Request.Cookies["refreshToken"];
                LoginResponse response = await _userRepository.RefreshToken(user, refreshToken, Response);
                _response.IsSuccess = response.Authorized;
                _response.Result = response;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("reset-password")]
        public async Task<object> ResetPassword(NewPasswordRequest newPasswordRequest)
        {
            try
            {
                bool result = await _userRepository.ResetPassword(newPasswordRequest);
                _response.IsSuccess = result;
                _response.DisplayMessage = result ? "Password Reset Successfully" : "Password Reset Failed";
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("forgot-password")]
        public async Task<object> ForgotPassword(string email)
        {
            try
            {
                bool result = await _userRepository.ForgotPassword(email);
                _response.IsSuccess = result;
                _response.DisplayMessage = result ? "Password Reset Link Sent to Email" : "Password Reset Failed";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
                return _response;
        }
        [HttpPost("verify-email/{token}")]
        public async Task<object> VerifyEmail(string token)
        {
            try
            {
                bool result = await _userRepository.VerifyEmail(token);
                _response.IsSuccess = result;
                _response.DisplayMessage = result ? "Email Verified Successfully" : "Email Verification Failed";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("create-artist")]
        public async Task<object> CreateArtist(Guid userId)
        {
            try
            {
                bool result = await _userRepository.CreateArtist(userId);
                _response.IsSuccess = result;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
