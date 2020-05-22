
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;

using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminRoleBusinessLogic : IEntityFrameworkBaseBusinessLogic<AdminRoleEntity>
    {
        
        ServiceResult<int> DeleteById(int id);
        ServiceResult<AdminRoleEntity> GetById(int id);
        ServiceResult<List<object>> Search(string name, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
