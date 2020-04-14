using System;
using System.Collections.Generic;
using System.Reflection;
using CoreCommon.Data.Domain.Business;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminRoleActionListBusinessLogic
    {
        ServiceResult<int> UpdateRoleActionList(List<Assembly> assemblies, Type baseControllerType);
    }
}     
