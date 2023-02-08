using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.API.User.Models;

public class UserRegisterRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;
}
