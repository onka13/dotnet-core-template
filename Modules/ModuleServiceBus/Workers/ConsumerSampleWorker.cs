using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using CoreCommon.Data.ServiceBus.Models;
using Microsoft.Extensions.Hosting;
using ModuleServiceBus.Managers;

namespace ModuleServiceBus.Workers
{
    /// <summary>
    /// Sample background service
    /// </summary>
    public class ConsumerSampleWorker : BackgroundService
    {
        /// <summary>
        /// Autofac component to resolve services.
        /// </summary>
        private readonly IComponentContext _componentContext;
        ServiceBusManager serviceBusManager;

        public ConsumerSampleWorker(IComponentContext context)
        {
            _componentContext = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            serviceBusManager = _componentContext.Resolve<ServiceBusManager>();
            var serviceBusHelper = serviceBusManager.InitHelper(ServiceBusManager.QUEUE1);
            serviceBusHelper.OnException = ExceptionReceivedHandler;
            serviceBusHelper.Receive((messageArgs, token) =>
            {
                Console.WriteLine("ServiceBus: received: {0}", messageArgs.GetDataAsString());
                return Task.FromResult(true);
            });    
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(60000, stoppingToken);
            }            
        }

        void ExceptionReceivedHandler(ServiceBusException e)
        {
            Console.WriteLine($"Message handler encountered an exception {e.Exception}.");
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {e.Endpoint}");
            Console.WriteLine($"- Entity Path: {e.EntityPath}");
            Console.WriteLine($"- Executing Action: {e.Action}");
        }
    }
}
