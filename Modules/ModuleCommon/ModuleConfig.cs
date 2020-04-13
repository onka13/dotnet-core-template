using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuleCommon.Business;
using Autofac;
using CoreCommon.Business.Service.Helpers;

namespace ModuleCommon
{
    /// <summary>
    /// Common Module Configuration 
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
        }

        /// <summary>
        /// Register types with using autofac builder
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            
        }
    }
}
