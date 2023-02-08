using CoreCommon.Data.RabbitMQ.Helpers;
using CoreCommon.Data.RabbitMQ.Models;
using CoreCommon.Infra.Helpers;
using Microsoft.Extensions.Options;
using ModuleRabbitMQ.Models;
using System;

namespace ModuleRabbitMQ.Managers
{
    /// <summary>
    /// RabbitMQ Manager
    /// </summary>
    public class RabbitMQManager
    {
        /// <summary>
        /// Sample Queue
        /// </summary>
        public QueueDeclareModel QueueSample { get; set; } = new QueueDeclareModel { Queue = "sample", Durable = true };

        /// <summary>
        /// Queue for emaling
        /// </summary>
        public QueueDeclareModel QueueEmail { get; set; } = new QueueDeclareModel { Queue = "UserEmail" };

        readonly RabbitMQHelper helper;

        public RabbitMQManager(IOptions<RabbitMQConfig> config)
        {
            if (config.Value == null || string.IsNullOrEmpty(config.Value.URL))
            {
                throw new ArgumentException("RabbitMQ configuration missing!");
            }

            helper = new RabbitMQHelper(config.Value.URL);
        }

        public RabbitMQHelper GetHelper()
        {
            return helper;
        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="message"></param>
        public void Send(QueueDeclareModel queue, string message)
        {
            helper.Send(queue.Queue, message, queue);
        }
        
        /// <summary>
        /// send data
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="body"></param>
        public void Send(QueueDeclareModel queue, object body)
        {
            helper.Send(queue.Queue, ConversionHelper.ObjectToByteArray(body), queue);
        }

        /// <summary>
        /// Basic consume
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="received"></param>
        /// <returns>connection key of consume</returns>
        public string BasicConsume(QueueDeclareModel queue, Func<BasicDeliverEventArgsModel, bool> received)
        {
            return helper.BasicConsume(queue.Queue, received,
                queueDeclare: queue,
                consume: new BasicConsumeModel
                {
                    AutoAck = false
                }, qos: new BasicQosModel
                {
                    PrefetchCount = 1
                });
        }
    }
}
