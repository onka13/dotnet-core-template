
using System.Collections.Generic;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using ModuleAdmin.Repositories;

using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;

namespace ModuleAdmin.Services
{
    public partial class AdminRoleDefinitionBusinessLogic
    {
        public ServiceResult<string> Sample1(string message)
        {
            var response = ServiceResult<string>.Instance.ErrorResult(ServiceResultCode.Error);
            response.SuccessResult("Message: " + message);
            return response;
        }            
    }
}
