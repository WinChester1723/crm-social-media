using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}