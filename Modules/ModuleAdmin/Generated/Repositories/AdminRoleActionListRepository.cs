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
    public partial class AdminRoleActionListRepository : EntityFrameworkBaseRepository<AdminRoleActionListEntity, MainConnectionDbContext>, IAdminRoleActionListRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public AdminRoleActionListEntity GetById(int id, bool includeRelations = false)
        {
            return GetBy(x => x.Id == id, includeRelations);
        }

        public int DeleteByModuleId(int moduleId)
        {            
            return DeleteBy(x => x.ModuleId == moduleId);
        }

        public List<AdminRoleActionListEntity> ListByModuleId(int moduleId, bool includeRelations = false)
        {
            return FindBy(x => x.ModuleId == moduleId, includeRelations).ToList();
        }

        public List<AdminRoleActionListEntity> ListByModuleId(int moduleId, int skip, int take, bool includeRelations = false)
        {
            return FindBy(x => x.ModuleId == moduleId, skip, take, includeRelations).ToList();
        }
    }
}
