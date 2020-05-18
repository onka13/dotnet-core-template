using Autofac;
using CoreCommon.Business.Service.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModuleCommon.API;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Net.Http;

namespace CoreTemplate.Application.OcelotApiGateway
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

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddOcelot(Configuration);
        }

        public async override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);
            await app.UseOcelot();
        }

        public override void ConfigureAppConfiguration(IConfigurationBuilder config, IHostEnvironment env)
        {
            base.ConfigureAppConfiguration(config, env);
            config.AddJsonFile("ocelot.json");
        }
    }
}
