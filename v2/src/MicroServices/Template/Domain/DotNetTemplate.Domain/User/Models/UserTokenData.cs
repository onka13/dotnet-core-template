namespace DotNetTemplate.Domain.User.Models;

/// <summary>
/// This model is used by JWT token.
/// </summary>
public class UserTokenData
{
    public string? Id { get; set; }

    public string? Email { get; set; }
}
