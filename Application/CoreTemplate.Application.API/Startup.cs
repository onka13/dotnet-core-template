using Autofac;
using CoreCommon.Business.Service.Helpers;
using Microsoft.Extensions.DependencyInjection;
using ModuleCommon.API;

namespace CoreTemplate.Application.API
{
    /// <summary>
    /// Startup of the project. Register types for IoC, configure host features.
    /// </summary>
    public class Startup : StartupCommon
    {
        public override void ConfigureContainer(ContainerBuilder builder)
        {
            DependencyHelper.RegisterCommonTypes(builder, GetType());
            base.ConfigureContainer(builder);            
        }
    }
}
