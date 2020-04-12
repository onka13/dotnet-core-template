
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

namespace ModuleAdmin.IServices
{
    public partial interface IAdminUserRoleMapBusinessLogic : IBusinessLogicBase<AdminUserRoleMapEntity>
    {
        
        ServiceResult<int> DeleteById(int id);
        ServiceResult<AdminUserRoleMapEntity> GetById(int id);
        ServiceResult<int> DeleteByUserId(int userId);
        ServiceResult<List<AdminUserRoleMapEntity>> ListByUserId(int userId);
        ServiceResult<List<AdminUserRoleMapEntity>> ListByUserId(int userId, int skip, int take);
        ServiceResult<List<object>> Search(int? userId,int? roleId, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
