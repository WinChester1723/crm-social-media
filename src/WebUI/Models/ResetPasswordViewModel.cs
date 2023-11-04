
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models;

public class ResetPasswordViewModel
{
    [Required]
    public string Token { get; set; } // Токен, используемый для проверки запроса на сброс пароля

    [Required]
    [EmailAddress]
    public string Email { get; set; } // Электронная почта пользователя

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "The new password must be at least 8 characters long.")]
    public string NewPassword { get; set; } // Новый пароль пользователя

    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } // Подтверждение нового пароля
}