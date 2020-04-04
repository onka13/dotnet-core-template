using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuleCommon.Business;
using Autofac;
using CoreCommon.Business.Service.Helpers;

namespace ModuleTemplate
{
    /// <summary>
    /// Account Module Configuration 
    /// </summary>
    public class ModuleConfig : IModuleConfig
    {
        /// <summary>
        /// Configure services.
        /// Sample usage;
        /// services.Configure<TemplateConfig>(configuration.GetSection("templateConfig"));
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="services"></param>
        public void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {

        }

        /// <summary>
        /// Register types with using autofac builder.
        /// Sample usage;
        /// builder.RegisterType<XXX>().AsSelf().InstancePerDependency();
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register types in this assembly
            DependencyHelper.RegisterCommonTypes(builder, typeof(ModuleConfig));
        }
    }
}
