using System;
using System.Text;
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
    public class ConsumerSampleWorker : BackgroundService
    {
        /// <summary>
        /// Autofac component to resolve services.
        /// </summary>
        private readonly IComponentContext _componentContext;
        RabbitMQManager rabbitMQManager;

        public ConsumerSampleWorker(IComponentContext context)
        {
            _componentContext = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            rabbitMQManager = _componentContext.Resolve<RabbitMQManager>();
            string connectionKey = rabbitMQManager.BasicConsume(rabbitMQManager.QueueSample, (e) =>
            {
                var message = e.GetDataAsString();
                Console.WriteLine("RabbitMQ: received: {0}", message);

                // return true for BasicAck
                return true;
            });

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(60000, stoppingToken);
            }
            rabbitMQManager.GetHelper().CloseConnection(connectionKey);
        }

        public override void Dispose()
        {
            if(rabbitMQManager != null) rabbitMQManager.GetHelper().Dispose();
            base.Dispose();
        }
    }
}
