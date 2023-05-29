using UserAPI.RabbitMq.Models;

namespace UserAPI.Models.Dto
{
    public class UserSignUp
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set;}
        public string UserName { get; set; }
        public IFormFile Image { get; set; }
    }
    public class SignUpResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public EmailHeader Email { get; set; }
    }
}
