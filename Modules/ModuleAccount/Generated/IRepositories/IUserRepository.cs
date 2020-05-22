﻿
using System;
using System.Collections.Generic;
using System.Linq;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;
using CoreCommon.Data.Domain.Business;
using System.Linq.Expressions;
using ModuleAccount.Generated.Entities;
using ModuleAccount.Generated.Enums;


namespace ModuleAccount.IRepositories
{
    public partial interface IUserRepository : IEntityFrameworkBaseRepository<UserEntity>
    {
        
        int DeleteById(int id);
        UserEntity GetById(int id);
        int DeleteByEmail(string email);
        UserEntity GetByEmail(string email);
        List<object> Search(int? id,string name,string email,bool? emailConfirmed,Status? status, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
