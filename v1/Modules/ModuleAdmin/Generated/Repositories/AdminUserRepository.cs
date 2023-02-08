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
    public partial class AdminUserRepository : EntityFrameworkBaseRepository<AdminUserEntity, MainConnectionDbContext>, IAdminUserRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public AdminUserEntity GetById(int id, bool includeRelations = false)
        {
            return GetBy(x => x.Id == id, includeRelations);
        }

        public List<object> Search(string name,string email,Status? status,int? id, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var result = GetDbSet().AsQueryable();
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            if (!string.IsNullOrEmpty(email))
                result = result.Where(x => x.Email.ToLower().Contains(email.ToLower()));
            if (status.HasValue)
                result = result.Where(x => x.Status.Equals(status));
            if (id.HasValue)
                result = result.Where(x => x.Id.Equals(id));
            var orderField = SortField(orderBy, x => x.Id);

            var selectFunc = Projection(x => new {
                x.Id,
				x.No,
				x.Name,
				x.Email,
				x.Status,
				x.IsSuper
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
