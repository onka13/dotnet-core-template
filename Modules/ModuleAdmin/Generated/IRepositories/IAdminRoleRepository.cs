
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
    public partial interface IAdminRoleRepository : IEntityFrameworkBaseRepository<AdminRoleEntity>
    {
        
        int DeleteById(int id);
        AdminRoleEntity GetById(int id);
        List<object> Search(string name, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
