using System.Collections.Generic;

namespace ModuleAdmin.IRepositories
{
    public partial interface IAdminUserRepository
    {
        bool HasAccess(int userId, string moduleKey, string pageKey, string actionKey);
        List<string> ListUserRoleActions(int userId, string moduleKey, string pageKey);
    }
}    
