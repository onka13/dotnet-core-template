using Autofac;
using CoreCommon.Business.Service.Helpers;
using Microsoft.Extensions.DependencyInjection;
using ModuleCommon.Business;
using CoreCommon.Business.Service.Base;
using ModuleRabbitMQ.Models;
using ModuleRabbitMQ.Workers;

namespace ModuleRabbitMQ
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
            services.Configure<RabbitMQConfig>(Configuration.GetSection("RabbitMQ"));
            DependencyManager.ConfigureServices(Configuration, services);

            services.AddHostedService<ProducerEmailWorker>();
            services.AddHostedService<ConsumerEmailWorker>();
            services.AddHostedService<ProducerSampleWorker>();
            services.AddHostedService<ConsumerSampleWorker>();
        }

        /// <summary>
        /// Registering types with using Autofac 
        /// </summary>
        /// <param name="builder"></param>
        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            DependencyManager.ConfigureContainer(builder);
            DependencyHelper.RegisterCommonTypes(builder, typeof(Program));
        }
    }
}
