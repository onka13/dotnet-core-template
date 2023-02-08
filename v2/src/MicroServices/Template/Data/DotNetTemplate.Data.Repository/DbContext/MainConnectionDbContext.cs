using DotNetCommon.Data.EntityFrameworkBase.Base;
using DotNetTemplate.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace DotNetTemplate.Data.Repository.DbContext;

public class MainConnectionDbContext : DbContextBase
{
    public override string Name { get => "MainConnection"; }

    public virtual DbSet<UserEntity> Users { get; set; }
}
