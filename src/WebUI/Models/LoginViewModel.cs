
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
    public string Password { get; set; }

     public bool RememberMe { get; set; }
}