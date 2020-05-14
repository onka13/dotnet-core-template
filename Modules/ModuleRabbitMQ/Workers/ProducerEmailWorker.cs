using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Hosting;
using ModuleAccount.IServices;
using ModuleRabbitMQ.Managers;
using ModuleRabbitMQ.Models;

namespace ModuleRabbitMQ.Workers
{
    /// <summary>
    /// Sample background service
    /// </summary>
    public class ProducerEmailWorker : BackgroundService
    {
        /// <summary>
        /// Autofac component to resolve services.
        /// </summary>
        private readonly IComponentContext _componentContext;

        public ProducerEmailWorker(IComponentContext context)
        {
            _componentContext = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var rabbitMQManager = _componentContext.Resolve<RabbitMQManager>();
            var userBusinessLogic = _componentContext.Resolve<IUserBusinessLogic>();

            while (!stoppingToken.IsCancellationRequested)
            {
                var users = userBusinessLogic.GetAll().Value.ToList();
                foreach (var user in users)
                {
                    rabbitMQManager.Send(rabbitMQManager.QueueEmail, new UserEmailQueueModel {
                        Id = user.Id,
                        Email = user.Email
                    });
                    Console.WriteLine("RabbitMQ: send {0}", user.Email);
                }

                await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
            }
        }
    }
}
