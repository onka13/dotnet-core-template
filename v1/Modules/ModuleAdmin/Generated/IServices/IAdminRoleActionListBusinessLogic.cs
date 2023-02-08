/*
Auto generated file. Do not edit!
*/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;
using Microsoft.EntityFrameworkCore;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminRoleActionListBusinessLogic : IEntityFrameworkBaseBusinessLogic<AdminRoleActionListEntity>
    {
        
        ServiceResult<int> DeleteById(int id);
        ServiceResult<AdminRoleActionListEntity> GetById(int id, bool includeRelations = false);
        ServiceResult<int> DeleteByModuleId(int moduleId);
        ServiceResult<List<AdminRoleActionListEntity>> ListByModuleId(int moduleId, bool includeRelations = false);
        ServiceResult<List<AdminRoleActionListEntity>> ListByModuleId(int moduleId, int skip, int take, bool includeRelations = false);
	}
}    
