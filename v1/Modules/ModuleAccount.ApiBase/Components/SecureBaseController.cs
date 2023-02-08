using ModuleAccount.ApiBase.Components.Attributes;
using ModuleCommon.ApiBase.Components;
using Microsoft.AspNetCore.Mvc;
using ModuleAccount.Models;

namespace ModuleAccount.ApiBase.Components
{
    /// <summary>
    /// Base controller for authenticated users
    /// </summary>
    [TypeFilter(typeof(AuthorizeActionFilter))]
    public abstract class SecureBaseController : BaseController
    {
        /// <summary>
        /// User id
        /// </summary>
        public int UserId
        {
            get
            {
                return (User.Identity as CoreIdentity).UserId;
            }
        }
        
        /// <summary>
        /// Gets user info
        /// </summary>
        /// <returns></returns>
        public UserInfo GetUserInfo()
        {
            var data = (User.Identity as CoreIdentity).UserData;
            return new UserInfo
            {
                Id = data.Id,
                Email = data.Email
            };
        }
    }
}
