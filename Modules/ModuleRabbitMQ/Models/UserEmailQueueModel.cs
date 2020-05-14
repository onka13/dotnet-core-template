using System;

namespace ModuleRabbitMQ.Models
{
    [Serializable]
    public class UserEmailQueueModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
