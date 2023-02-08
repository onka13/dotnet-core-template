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
using ModuleAccount.Generated.Entities;
using ModuleAccount.Generated.Enums;
using ModuleAccount.IRepositories;
using ModuleAccount.Generated.Data;
using CoreCommon.Data.EntityFrameworkBase.Base;
using Microsoft.EntityFrameworkCore;

namespace ModuleAccount.Repositories
{
    public partial class UserRepository : EntityFrameworkBaseRepository<UserEntity, MainConnectionDbContext>, IUserRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public UserEntity GetById(int id, bool includeRelations = false)
        {
            return GetBy(x => x.Id == id, includeRelations);
        }

        public int DeleteByEmail(string email)
        {            
            return DeleteBy(x => x.Email == email);
        }

        public UserEntity GetByEmail(string email, bool includeRelations = false)
        {
            return GetBy(x => x.Email == email, includeRelations);
        }

        public List<object> Search(int? id,string name,string email,bool? emailConfirmed,Status? status, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var result = GetDbSet().AsQueryable();
            if (id.HasValue)
                result = result.Where(x => x.Id.Equals(id));
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            if (!string.IsNullOrEmpty(email))
                result = result.Where(x => x.Email.ToLower().Contains(email.ToLower()));
            if (emailConfirmed.HasValue)
                result = result.Where(x => x.EmailConfirmed.Equals(emailConfirmed));
            if (status.HasValue)
                result = result.Where(x => x.Status.Equals(status));
            var orderField = SortField(orderBy, x => x.Id,x => x.Email);

            var selectFunc = Projection(x => new {
                x.Id,
				x.Name,
				x.Email,
				x.EmailConfirmed,
				x.Status
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
