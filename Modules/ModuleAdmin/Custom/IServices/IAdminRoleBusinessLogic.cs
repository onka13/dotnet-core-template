using System.Collections.Generic;
using CoreCommon.Data.Domain.Business;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminRoleBusinessLogic
    {
        ServiceResult<object> SaveMap(List<string> roles);
    }
}     
