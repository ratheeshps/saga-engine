using MassTransit.Definition;
using MassTransit;
using MassTransit.Saga;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using saga_state.machine;
using rabbitmqbus;

namespace saga_machine
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var saga = new RemitterStateMachine();
            var repo = new InMemorySagaRepository<RemitterStateData>();

            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
                   services.AddMassTransit(cfg =>
                   {
                       cfg.AddBus(provider => ServiceBus.ConfigureBus(provider, (cfg, host) =>
                       {
                           cfg.ReceiveEndpoint(BusConfiguration.SagaQueue, e =>
                           {
                               e.StateMachineSaga(saga, repo);
                           });
                       }));

                   });
                   services.AddMassTransitHostedService();
               });

            await builder.RunConsoleAsync();
        }
    }
}
