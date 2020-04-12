using System.Collections.Generic;
using CoreCommon.Data.Domain.Business;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminUserRoleMapBusinessLogic
    {
        ServiceResult<object> SaveUserRoles(int userId, List<int> roleIds);
    }
}     
