using ModuleAccount.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace ModuleAccountApi.Components
{
    /// <summary>
    /// Identity class
    /// </summary>
    public class CoreIdentity : ClaimsIdentity
    {
        /// <summary>
        /// User jwt data
        /// </summary>
        public UserTokenData UserData { get; set; }

        public CoreIdentity(UserTokenData userData)
        {
            UserData = userData;
        }

        public CoreIdentity(UserTokenData userData, IEnumerable<Claim> claims) : base(claims, DefaultNameClaimType)
        {
            UserData = userData;
        }
        /// <summary>
        /// User email
        /// </summary>
        public override string Name => UserData?.Email;

        /// <summary>
        /// Is Auth
        /// </summary>
        public override bool IsAuthenticated { get { return UserData?.Id > 0; } }

        /// <summary>
        /// User id
        /// </summary>
        public int UserId { get { return UserData?.Id ?? 0; } }
    }
}
