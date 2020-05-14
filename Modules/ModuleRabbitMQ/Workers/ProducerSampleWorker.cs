using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Hosting;
using ModuleRabbitMQ.Managers;

namespace ModuleRabbitMQ.Workers
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
            var rabbitMQManager = _componentContext.Resolve<RabbitMQManager>();

            while (!stoppingToken.IsCancellationRequested)
            {
                rabbitMQManager.Send(rabbitMQManager.QueueSample, "Hi sample " + DateTime.Now);
                Console.WriteLine("RabbitMQ: send");
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}
