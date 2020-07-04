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

namespace ModuleAdmin.Repositories
{
    public partial class AdminRoleRepository : EntityFrameworkBaseRepository<AdminRoleEntity, MainConnectionDbContext>, IAdminRoleRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public AdminRoleEntity GetById(int id)
        {
            return GetBy(x => x.Id == id);
        }

        public List<object> Search(string name, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var result = GetDbSet().AsQueryable();
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            var dic = new Dictionary<string, Expression<Func<AdminRoleEntity, object>>>
            {
                {"id", x => x.Id}
            };

            Expression<Func<AdminRoleEntity, object>> selectFunc = x => new {
                x.Id,
				x.Name
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
