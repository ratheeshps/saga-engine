using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmqbus
{
    public class BusConfiguration
    {
        public const string QueueEndPoint = "rabbitmq://localhost";
        public const string Username = "guest";
        public const string Password = "guest";
        public const string QueueName = "remitter-queue";
        public const string AmlQueueName = "Aml-queue";
        public const string SagaQueue = "saga-queue";
    }
}
