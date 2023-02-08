using DotNetCommon.Application.WebAPIBase.Controllers;
using Microsoft.AspNetCore.Mvc;
using Shared.ApplicationWebBase.User;
using Shared.Domain.User;

namespace Shared.ApplicationWebBase.BaseComponents;

/// <summary>
/// Base controller for authenticated users
/// </summary>
[TypeFilter(typeof(AuthorizeActionFilter))]
public abstract class SharedSecureController : BaseController
{
    /// <summary>
    /// User id
    /// </summary>
    protected string? UserId
    {
        get { return GetUser()?.Id; }
    }

    /// <summary>
    /// Gets user info
    /// </summary>
    /// <returns></returns>
    protected UserInfo? GetUserInfo()
    {
        var data = GetUser();
        if (data == null)
        {
            return null;
        }

        return new UserInfo
        {
            Id = data.Id,
            Email = data.Email,
        };
    }

    protected UserTokenData? GetUser()
    {
        return (User.Identity as UserIdentity)?.UserData;
    }
}
