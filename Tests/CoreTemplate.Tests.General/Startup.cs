using Autofac;
using CoreCommon.Business.Service.IoC;
using CoreTemplate.Business.Service.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CoreTemplate.Tests.General
{
    /// <summary>
    /// Startup of the project. Register types for IoC, configure host features.
    /// </summary>
    public class Startup : StartupBase
    {
        /// <summary>
        /// Add services to IoC.  
        /// </summary>
        /// <param name="services"></param>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            DependencyManager.ConfigureServices(Configuration, services);
        }

        /// <summary>
        /// Registering types with using Autofac 
        /// </summary>
        /// <param name="builder"></param>
        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            DependencyManager.ConfigureContainer(builder);
        }
    }
}
