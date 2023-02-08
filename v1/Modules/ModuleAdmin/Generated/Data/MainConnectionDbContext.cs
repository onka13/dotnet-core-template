/*
Auto generated file. Do not edit!
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CoreCommon.Data.EntityFrameworkBase.Base;
using ModuleAdmin.Generated.Entities;

namespace ModuleAdmin.Generated.Data
{
    public class MainConnectionDbContext : DbContextBase
    {
        public override string Name { get => "MainConnection"; }

        
        public virtual DbSet<AdminRoleEntity> AdminRoles { get; set; }

        public virtual DbSet<AdminRoleActionListEntity> AdminRoleActionLists { get; set; }

        public virtual DbSet<AdminRoleDefinitionEntity> AdminRoleDefinitions { get; set; }

        public virtual DbSet<AdminUserEntity> AdminUsers { get; set; }

        public virtual DbSet<AdminUserRoleMapEntity> AdminUserRoleMaps { get; set; }

    }
}
