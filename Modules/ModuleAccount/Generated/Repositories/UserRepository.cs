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

namespace ModuleAccount.Repositories
{
    public partial class UserRepository : EntityFrameworkBaseRepository<UserEntity, MainConnectionDbContext>, IUserRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public UserEntity GetById(int id)
        {
            return GetBy(x => x.Id == id);
        }

        public int DeleteByEmail(string email)
        {            
            return DeleteBy(x => x.Email == email);
        }

        public UserEntity GetByEmail(string email)
        {
            return GetBy(x => x.Email == email);
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
            var dic = new Dictionary<string, Expression<Func<UserEntity, object>>>
            {
                {"id", x => x.Id},{"email", x => x.Email}
            };

            Expression<Func<UserEntity, object>> selectFunc = x => new {
                x.Id,
				x.Name,
				x.Email,
				x.EmailConfirmed,
				x.Status
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
