/*
Auto generated file. Do not edit!
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CoreCommon.Data.EntityFrameworkBase.Base;
using ModuleAccount.Generated.Entities;

namespace ModuleAccount.Generated.Data
{
    public class MainConnectionDbContext : DbContextBase
    {
        public override string Name { get => "MainConnection"; }

        
        public virtual DbSet<UserEntity> Users { get; set; }

    }
}
