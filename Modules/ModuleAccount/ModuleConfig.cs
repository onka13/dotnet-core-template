using ModuleAccount.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuleCommon.Business;
using Autofac;
using CoreCommon.Business.Service.Helpers;

namespace ModuleAccount
{
    /// <summary>
    /// Account Module Configuration 
    /// </summary>
    public class ModuleConfig : IModuleConfig
    {
        /// <summary>
        /// Configure services
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="services"></param>
        public void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.Configure<UserConfig>(configuration.GetSection("User"));
        }

        /// <summary>
        /// Register types with using autofac builder
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            DependencyHelper.RegisterCommonTypes(builder, typeof(ModuleConfig));
        }
    }
}
