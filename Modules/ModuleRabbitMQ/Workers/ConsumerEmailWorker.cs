using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Hosting;
using ModuleRabbitMQ.Managers;
using ModuleRabbitMQ.Models;

namespace ModuleRabbitMQ.Workers
{
    /// <summary>
    /// Sample consumer for emailing background service
    /// </summary>
    public class ConsumerEmailWorker : BackgroundService
    {
        /// <summary>
        /// Autofac component to resolve services.
        /// </summary>
        private readonly IComponentContext _componentContext;
        RabbitMQManager rabbitMQManager;

        public ConsumerEmailWorker(IComponentContext context)
        {
            _componentContext = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            rabbitMQManager = _componentContext.Resolve<RabbitMQManager>();

            // start to listen queue
            string connectionKey = rabbitMQManager.BasicConsume(rabbitMQManager.QueueEmail, (e) =>
            {
                var model = e.GetDataAs<UserEmailQueueModel>();
                Console.WriteLine("RabbitMQ: received: {0}:{1}", model.Id, model.Email);

                // send email

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
