
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using ModuleAdmin.IRepositories;
using ModuleAdmin.Generated.Data;

using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;
using CoreCommon.Data.ElasticSearch.Base;
using CoreCommon.Data.Domain.Business;

namespace ModuleAdmin.Repositories
{
    public partial class AdminRoleDefinitionRepository : EntityFrameworkBaseRepository<AdminRoleDefinitionEntity, MainConnectionDbContext>, IAdminRoleDefinitionRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public AdminRoleDefinitionEntity GetById(int id)
        {
            return GetBy(x => x.Id == id);
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
            var dic = new Dictionary<string, Func<AdminRoleDefinitionEntity, object>>
            {
                {"id", x => x.Id}
            };

            Func<AdminRoleDefinitionEntity, object> selectFunc = x => new {
                x.Id,
				x.RoleId,
				x.ModuleKey,
				x.PageKey,
				x.ActionKey,
				x.Action
            };
            
            if (!string.IsNullOrEmpty(orderBy) && dic.ContainsKey(orderBy))
            {
                var result2 = asc ? result.OrderBy(dic[orderBy]) : result.OrderByDescending(dic[orderBy]);
                return SkipTake(result2.Select(selectFunc), skip, take, out _total);
            }
            return SkipTake(result.Select(selectFunc), skip, take, out _total);
        }
    }
}
