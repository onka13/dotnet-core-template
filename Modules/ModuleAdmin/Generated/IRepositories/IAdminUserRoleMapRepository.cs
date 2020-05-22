
using System;
using System.Collections.Generic;
using System.Linq;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;
using CoreCommon.Data.ElasticSearch.Base;
using CoreCommon.Data.Domain.Business;
using System.Linq.Expressions;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;


namespace ModuleAdmin.IRepositories
{
    public partial interface IAdminUserRoleMapRepository : IEntityFrameworkBaseRepository<AdminUserRoleMapEntity>
    {
        
        int DeleteById(int id);
        AdminUserRoleMapEntity GetById(int id);
        int DeleteByUserId(int userId);
        List<AdminUserRoleMapEntity> ListByUserId(int userId);
        List<AdminUserRoleMapEntity> ListByUserId(int userId, int skip, int take);
        List<object> Search(int? userId,int? roleId, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
