﻿/*
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
    public partial interface IAdminUserRepository : IEntityFrameworkBaseRepository<AdminUserEntity>
    {
        
        int DeleteById(int id);
        AdminUserEntity GetById(int id, bool includeRelations = false);
        List<object> Search(string name,string email,Status? status,int? id, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
