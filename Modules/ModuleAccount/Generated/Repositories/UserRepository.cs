
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ModuleAccount.Generated.Entities;
using ModuleAccount.Generated.Enums;
using ModuleAccount.IRepositories;
using ModuleAccount.Generated.Data;

using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;
using CoreCommon.Data.ElasticSearch.Base;
using CoreCommon.Data.Domain.Business;

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
    }
}
