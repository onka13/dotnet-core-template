namespace Shared.Domain.User;

/// <summary>
/// User configuration model which defined in appsettings.
/// </summary>
public class UserConfig
{
    public string? UserTokenSecret { get; set; }

    public string? UserPasswordSalt { get; set; }

    public string TokenName { get; set; } = string.Empty;

    public int ExpiryDurationInMinutes { get; set; } = 60;

    public string CookieDomain { get; set; } = string.Empty;
}
