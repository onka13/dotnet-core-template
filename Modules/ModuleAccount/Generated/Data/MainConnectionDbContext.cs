
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModuleAccount.Generated.Entities;
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleAccount.Generated.Data
{
    public class MainConnectionDbContext : DbContextBase
    {
        public override string Name { get => "MainConnection"; }

        
        public virtual DbSet<UserEntity> Users { get; set; }

    }
}
