using System.ComponentModel.DataAnnotations;

namespace WebUI.Models;

public class UserProfileViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string Phone { get; set; }

    public string Address { get; set; }
    // Добавьте другие поля по мере необходимости
}