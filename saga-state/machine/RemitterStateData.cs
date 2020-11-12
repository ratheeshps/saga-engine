using Automatonymous;
using System;
using System.Collections.Generic;
using System.Text;

namespace saga_state.machine
{
    //Saga Implmentation for RabbitMQ
    public class RemitterStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public Guid RemitterID { get; set; }
        public string RemitterFirstName { get; set; }
        public string RemitterLastName { get; set; }
        public string RemitterCountry { get; set; }
        public string RemitterStatus { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? ScreenedDateTime { get; set; }
    }
}
