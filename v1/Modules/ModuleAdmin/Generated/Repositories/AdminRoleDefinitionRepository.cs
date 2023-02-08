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
using ModuleAdmin.IRepositories;
using ModuleAdmin.Generated.Data;
using CoreCommon.Data.EntityFrameworkBase.Base;
using Microsoft.EntityFrameworkCore;

namespace ModuleAdmin.Repositories
{
    public partial class AdminRoleDefinitionRepository : EntityFrameworkBaseRepository<AdminRoleDefinitionEntity, MainConnectionDbContext>, IAdminRoleDefinitionRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public AdminRoleDefinitionEntity GetById(int id, bool includeRelations = false)
        {
            return GetBy(x => x.Id == id, includeRelations);
        }

        public List<object> Search(int? roleId,string moduleKey,string pageKey,string actionKey, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var result = GetDbSet().AsQueryable();
            if (roleId.HasValue)
                result = result.Where(x => x.RoleId.Equals(roleId));
            if (!string.IsNullOrEmpty(moduleKey))
                result = result.Where(x => x.ModuleKey.ToLower().Contains(moduleKey.ToLower()));
            if (!string.IsNullOrEmpty(pageKey))
                result = result.Where(x => x.PageKey.ToLower().Contains(pageKey.ToLower()));
            if (!string.IsNullOrEmpty(actionKey))
                result = result.Where(x => x.ActionKey.ToLower().Contains(actionKey.ToLower()));
            var orderField = SortField(orderBy, x => x.Id);

            var selectFunc = Projection(x => new {
                x.Id,
				x.RoleId,
				x.ModuleKey,
				x.PageKey,
				x.ActionKey,
				x.Action
            });
            if (orderField != null)
            {
                var result2 = asc ? result.OrderBy(orderField) : result.OrderByDescending(orderField);
                return SkipTake(result2.Select(selectFunc), skip, take, out _total);
            }
            return SkipTake(result.Select(selectFunc), skip, take, out _total);
        }
            
    }
}
