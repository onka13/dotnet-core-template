using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleTest.Generated.Entities;
using ModuleTest.Generated.Enums;
using ModuleTest.Repositories;

namespace ModuleTest.Services
{
    public partial class BookEfBusinessLogic
    {
        public ServiceResult<string> Sample1(string message)
        {
            var response = ServiceResult<string>.Instance.ErrorResult(ServiceResultCode.Error);
            response.SuccessResult("Message: " + message);
            return response;
        }            
    }
}
