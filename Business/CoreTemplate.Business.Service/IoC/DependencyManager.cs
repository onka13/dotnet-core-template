using Autofac;
using CoreCommon.Business.Service.IoC;
using CoreCommon.Data.Domain.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuleCommon.Business;

namespace CoreTemplate.Business.Service.IoC
{
    /// <summary>
    /// Dependency manager
    /// </summary>
    public class DependencyManager
    {
        /// <summary>
        /// Configure services
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="services"></param>
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.Configure<SmtpConfig>(configuration.GetSection("Smtp"));
            services.Configure<AppSettingsConfig>(configuration.GetSection("AppSettings"));

            foreach (var moduleConfig in ModuleHelper.GetModules())
            {
                moduleConfig.ConfigureServices(configuration, services);
            }
        }

        /// <summary>
        /// Register types
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            DependencyHelper.RegisterCommonTypes(builder, typeof(CoreCommon.Data.EntityFrameworkBase.Components.EmptyDbContext));

            foreach (var moduleConfig in ModuleHelper.GetModules())
            {
                moduleConfig.ConfigureContainer(builder);
            }
        }
    }
}
