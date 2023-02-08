namespace Shared.Domain.User;

/// <summary>
/// This model is used by JWT token.
/// </summary>
public class UserTokenData
{
    public string? Id { get; set; }

    public string? Email { get; set; }

    public UserAuthSchema AuthSchema { get; set; } = UserAuthSchema.Web;
}
