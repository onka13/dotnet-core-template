
using System;
using System.Collections.Generic;
using System.Linq;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;

using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminRoleDefinitionBusinessLogic
    {
        ServiceResult<string> Sample1(string message);
	}
}     
