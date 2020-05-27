/*
Auto generated file. Do not edit!
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CoreCommon.Data.EntityFrameworkBase.Base;
using ModuleTest.Generated.Entities;

namespace ModuleTest.Generated.Data
{
    public class MainConnectionDbContext : DbContextBase
    {
        public override string Name { get => "MainConnection"; }

        
        public virtual DbSet<BookEfEntity> BookEfs { get; set; }

    }
}
