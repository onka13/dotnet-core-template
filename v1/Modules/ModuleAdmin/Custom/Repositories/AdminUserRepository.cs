
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ModuleAdmin.Generated.Data;

namespace ModuleAdmin.Repositories
{
    public partial class AdminUserRepository
    {
        public bool HasAccess(int userId, string moduleKey, string pageKey, string actionKey)
        {
            var context = (MainConnectionDbContext)GetDbContext();
            var definitions = context.AdminRoleDefinitions.Where(x => context.AdminUserRoleMaps.Where(y => y.UserId == userId && x.ModuleKey == moduleKey && x.PageKey == pageKey).Select(z => z.RoleId).Contains(x.RoleId));
            return definitions.Select(x => x.ActionKey).Any(x => x == actionKey || x == "admin");
        }

        public List<string> ListUserRoleActions(int userId, string moduleKey, string pageKey)
        {
            var context = (MainConnectionDbContext)GetDbContext();
            var definitions = context.AdminRoleDefinitions.Where(x => context.AdminUserRoleMaps.Where(y => y.UserId == userId && x.ModuleKey == moduleKey && x.PageKey == pageKey).Select(z => z.RoleId).Contains(x.RoleId));
            return definitions.Select(x => x.ActionKey).ToList();
        }
    }
}