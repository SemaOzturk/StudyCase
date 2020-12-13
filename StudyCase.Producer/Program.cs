using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudyCase.DTO;

namespace StudyCase.Producer2
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static async Task Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(configurator =>
            {
                configurator.Host("localhost", "/", hostConfigurator =>
                {
                    hostConfigurator.Username("guest");
                    hostConfigurator.Password("guest");
                });
                // configurator.ReceiveEndpoint("testQueue", endpointConfigurator =>
                // {
                //     endpointConfigurator.Handler<Message>(context => Console.Out.WriteLineAsync($"Received : {context.Message.Title}"));
                // });
            });

            await busControl.StartAsync();
            
            await Host.CreateDefaultBuilder(args)
                .ConfigureServices(((context, collection) =>
                {
                    collection.AddScoped(x => busControl);
                    collection.AddHostedService<Publisher>();
                })).StartAsync();
            
            // await busControl.Publish(new Message {Title = "Communication Request Started"});
            Console.ReadKey();
        }

        static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices(((context, collection) => { collection.AddHostedService<Publisher>(); }));
    }
}