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
    public partial class AdminUserRoleMapRepository : EntityFrameworkBaseRepository<AdminUserRoleMapEntity, MainConnectionDbContext>, IAdminUserRoleMapRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public AdminUserRoleMapEntity GetById(int id, bool includeRelations = false)
        {
            return GetBy(x => x.Id == id, includeRelations);
        }

        public int DeleteByUserId(int userId)
        {            
            return DeleteBy(x => x.UserId == userId);
        }

        public List<AdminUserRoleMapEntity> ListByUserId(int userId, bool includeRelations = false)
        {
            return FindBy(x => x.UserId == userId, includeRelations).ToList();
        }

        public List<AdminUserRoleMapEntity> ListByUserId(int userId, int skip, int take, bool includeRelations = false)
        {
            return FindBy(x => x.UserId == userId, skip, take, includeRelations).ToList();
        }

        public List<object> Search(int? userId,int? roleId, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var result = GetDbSet().Include(x => x.Role).AsQueryable();
            if (userId.HasValue)
                result = result.Where(x => x.UserId.Equals(userId));
            if (roleId.HasValue)
                result = result.Where(x => x.RoleId.Equals(roleId));
            var orderField = SortField(orderBy, x => x.Id,x => x.UserId);

            var selectFunc = Projection(x => new {
                x.Id,
				x.UserId,
				x.RoleId
            });
            if (orderField != null)
            {
                var result2 = asc ? result.OrderBy(orderField) : result.OrderByDescending(orderField);
                return SkipTake(result2.Select(selectFunc), skip, take, out _total);
            }
            return SkipTake(result.Select(selectFunc), skip, take, out _total);
        }
            

        public IQueryable<AdminUserRoleMapEntity> WithRelations(Expression<Func<AdminUserRoleMapEntity, bool>> predicate)
        {
            return GetDbSet().Include(x => x.Role).Where(predicate)
                .Select(x => new AdminUserRoleMapEntity{
                    Id= x.Id,
					UserId= x.UserId,
					RoleId= x.RoleId,
					Role = x.Role != null ? new AdminRoleEntity{ Id=x.Role.Id,Name=x.Role.Name  } : null
                });
        }

        public int EditWithRelations(AdminUserRoleMapEntity entity)
        {
            SetStateOnly(entity, EntityState.Modified);
            
            return Save();
        }
    }
}
