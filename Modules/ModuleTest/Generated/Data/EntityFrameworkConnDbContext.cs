/*
Auto generated file. Do not edit!
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CoreCommon.Data.EntityFrameworkBase.Base;
using ModuleTest.Generated.Entities;

namespace ModuleTest.Generated.Data
{
    public class EntityFrameworkConnDbContext : DbContextBase
    {
        public override string Name { get => "EntityFrameworkConn"; }

        
        public virtual DbSet<BookEfEntity> BookEfs { get; set; }

    }
}
