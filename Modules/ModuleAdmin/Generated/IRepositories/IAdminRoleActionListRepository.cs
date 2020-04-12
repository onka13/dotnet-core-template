
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
    public partial interface IAdminRoleActionListRepository : IRepositoryBase<AdminRoleActionListEntity>
    {
        
        int DeleteById(int id);
        AdminRoleActionListEntity GetById(int id);
        int DeleteByModuleId(int moduleId);
        List<AdminRoleActionListEntity> ListByModuleId(int moduleId);
        List<AdminRoleActionListEntity> ListByModuleId(int moduleId, int skip, int take);
	}
}    
