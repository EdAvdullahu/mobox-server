namespace UserAPI.Models.Dto
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Authorized { get; set; }
    }
}
