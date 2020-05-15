using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Hosting;
using ModuleServiceBus.Managers;

namespace ModuleServiceBus.Workers
{
    /// <summary>
    /// Sample background service
    /// </summary>
    public class ProducerSampleWorker : BackgroundService
    {
        /// <summary>
        /// Autofac component to resolve services.
        /// </summary>
        private readonly IComponentContext _componentContext;

        public ProducerSampleWorker(IComponentContext context)
        {
            _componentContext = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var serviceBusManager = _componentContext.Resolve<ServiceBusManager>();
            var serviceBusHelper = serviceBusManager.InitHelper(ServiceBusManager.QUEUE1);

            while (!stoppingToken.IsCancellationRequested)
            {
                await serviceBusHelper.Send("Hi sample " + DateTime.Now);
                Console.WriteLine("ServiceBus: send");
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}
