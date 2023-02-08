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
using CoreCommon.Data.EntityFrameworkBase.Base;
using Microsoft.EntityFrameworkCore;

namespace ModuleAdmin.IRepositories
{
    public partial interface IAdminRoleActionListRepository : IEntityFrameworkBaseRepository<AdminRoleActionListEntity>
    {
        
        int DeleteById(int id);
        AdminRoleActionListEntity GetById(int id, bool includeRelations = false);
        int DeleteByModuleId(int moduleId);
        List<AdminRoleActionListEntity> ListByModuleId(int moduleId, bool includeRelations = false);
        List<AdminRoleActionListEntity> ListByModuleId(int moduleId, int skip, int take, bool includeRelations = false);
	}
}    
