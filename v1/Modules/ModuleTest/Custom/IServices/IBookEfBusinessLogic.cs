using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleTest.Generated.Entities;
using ModuleTest.Generated.Enums;

namespace ModuleTest.IServices
{
    public partial interface IBookEfBusinessLogic
    {
        ServiceResult<string> Sample1(string message);
	}
}     
