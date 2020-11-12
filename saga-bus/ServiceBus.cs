using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace rabbitmqbus
{
    public class ServiceBus
    {
        public static IBusControl ConfigureBus(IServiceProvider provider, Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost>
         registrationAction = null)
        {
          
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
             var  host = cfg.Host(new Uri(BusConfiguration.QueueEndPoint), hst =>
                {
                    hst.Username(BusConfiguration.Username);
                    hst.Password(BusConfiguration.Password);
                });

                cfg.ConfigureEndpoints(provider);

                registrationAction?.Invoke(cfg, host);
            });
        }
    }
}
