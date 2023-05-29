using UserAPI.Models.Dto;

namespace UserAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<LoginResponse> AuthorizeUser(UserLogin userLogin, HttpResponse response);
        Task<SignUpResponse> SignUpUser(UserSignUp userSignUp);
        Task<LoginResponse> RefreshToken(LoginResponse loginResponse, string refreshToken, HttpResponse response);
        Task<bool> ResetPassword(NewPasswordRequest request);
        Task<bool> ForgotPassword(string email);
        Task<bool> VerifyEmail(string token);
    }
}
