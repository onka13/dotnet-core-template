using CoreCommon.Data.RabbitMQ.Helpers;
using Microsoft.Extensions.Options;
using ModuleServiceBus.Models;
using System;

namespace ModuleServiceBus.Managers
{
    /// <summary>
    /// ServiceBus Manager
    /// </summary>
    public class ServiceBusManager
    {
        public const string QUEUE1 = "queue1";

        readonly string serviceBusConnectionString;

        public ServiceBusManager(IOptions<ServiceBusConfig> config)
        {
            if (config.Value == null || string.IsNullOrEmpty(config.Value.ConnectionString))
            {
                throw new ArgumentException("ServiceBus configuration missing!");
            }
            serviceBusConnectionString = config.Value.ConnectionString;
        }

        public ServiceBusHelper InitHelper(string queue)
        {
            return new ServiceBusHelper(serviceBusConnectionString, queue);
        }
    }
}
