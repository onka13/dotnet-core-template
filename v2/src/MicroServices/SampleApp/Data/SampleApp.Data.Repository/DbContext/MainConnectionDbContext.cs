using DotNetCommon.Data.EntityFrameworkBase.Base;
using Microsoft.EntityFrameworkCore;
using SampleApp.Domain.Feedback;

namespace SampleApp.Data.Repository.DbContext;

public class MainConnectionDbContext : DbContextBase
{
    public override string Name { get => "MainConnection"; }

    public virtual DbSet<FeedbackEntity> Feedbacks { get; set; }
}
