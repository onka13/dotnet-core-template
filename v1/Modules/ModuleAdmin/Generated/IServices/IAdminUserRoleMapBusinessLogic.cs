/*
Auto generated file. Do not edit!
*/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;
using Microsoft.EntityFrameworkCore;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminUserRoleMapBusinessLogic : IEntityFrameworkBaseBusinessLogic<AdminUserRoleMapEntity>
    {
        
        ServiceResult<int> DeleteById(int id);
        ServiceResult<AdminUserRoleMapEntity> GetById(int id, bool includeRelations = false);
        ServiceResult<int> DeleteByUserId(int userId);
        ServiceResult<List<AdminUserRoleMapEntity>> ListByUserId(int userId, bool includeRelations = false);
        ServiceResult<List<AdminUserRoleMapEntity>> ListByUserId(int userId, int skip, int take, bool includeRelations = false);
        ServiceResult<List<object>> Search(int? userId,int? roleId, string orderBy, bool asc, int skip, int take, out long _total);
        ServiceResult<AdminUserRoleMapEntity> GetByWithRelations(Expression<Func<AdminUserRoleMapEntity, bool>> predicate);
        ServiceResult<List<AdminUserRoleMapEntity>> ListWithRelations(Expression<Func<AdminUserRoleMapEntity, bool>> predicate, int skip, int take);
        ServiceResult<int> EditWithRelations(AdminUserRoleMapEntity entity);
	}
}    
