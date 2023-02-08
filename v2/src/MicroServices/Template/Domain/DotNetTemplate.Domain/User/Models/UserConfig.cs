namespace DotNetTemplate.Domain.User.Models;

/// <summary>
/// User configuration model which defined in appsettings.
/// </summary>
public class UserConfig
{
    public string? UserTokenSecret { get; set; }

    public string? UserPasswordSalt { get; set; }
}
