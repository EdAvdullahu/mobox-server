using System.ComponentModel.DataAnnotations;

namespace Mobox.Service.Identity.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
