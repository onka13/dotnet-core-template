/*
Auto generated file. Do not edit!
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreCommon.Data.Domain.Enums;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Business;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;
using Microsoft.EntityFrameworkCore;

namespace ModuleAdmin.IRepositories
{
    public partial interface IAdminUserRoleMapRepository : IEntityFrameworkBaseRepository<AdminUserRoleMapEntity>
    {
        
        int DeleteById(int id);
        AdminUserRoleMapEntity GetById(int id, bool includeRelations = false);
        int DeleteByUserId(int userId);
        List<AdminUserRoleMapEntity> ListByUserId(int userId, bool includeRelations = false);
        List<AdminUserRoleMapEntity> ListByUserId(int userId, int skip, int take, bool includeRelations = false);
        List<object> Search(int? userId,int? roleId, string orderBy, bool asc, int skip, int take, out long _total);
        IQueryable<AdminUserRoleMapEntity> WithRelations(Expression<Func<AdminUserRoleMapEntity, bool>> predicate);
        int EditWithRelations(AdminUserRoleMapEntity entity);
	}
}    
