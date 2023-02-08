using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleCommon.Business
{
    /// <summary>
    /// Module Config interface. 
    /// </summary>
    public interface IModuleConfig
    {
        void ConfigureServices(IConfiguration configuration, IServiceCollection services);
        void ConfigureContainer(ContainerBuilder builder);
    }
}
