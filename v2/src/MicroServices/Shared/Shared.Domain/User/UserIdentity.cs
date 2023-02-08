using System.Security.Claims;

namespace Shared.Domain.User;

/// <summary>
/// Identity class
/// </summary>
public class UserIdentity : ClaimsIdentity
{
    public UserIdentity(UserTokenData userData)
    {
        UserData = userData;
    }

    public UserIdentity(UserTokenData userData, IEnumerable<Claim> claims)
        : base(claims, DefaultNameClaimType)
    {
        UserData = userData;
    }

    /// <summary>
    /// User jwt data
    /// </summary>
    public UserTokenData UserData { get; set; }

    /// <summary>
    /// User email
    /// </summary>
    public override string? Name => UserData?.Email;

    /// <summary>
    /// Is Auth
    /// </summary>
    public override bool IsAuthenticated
    {
        get { return UserData != null; }
    }

    /// <summary>
    /// User id
    /// </summary>
    public string? UserId
    {
        get
        {
            return UserData?.Id;
        }
    }
}