using System.ComponentModel.DataAnnotations;

namespace WebUI.Models;

public class ChangePasswordViewModel
{
    [Required]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "The new password must be at least 8 characters long.")]
    public string NewPassword { get; set; }
}