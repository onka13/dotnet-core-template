using System;
using System.Collections.Generic;
using CoreCommon.Data.Domain.Business;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminRoleActionListBusinessLogic
    {
        ServiceResult<int> UpdateRoleActionList(List<Type> modules, Type baseControllerType);
    }
}     
