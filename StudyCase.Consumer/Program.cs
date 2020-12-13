using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Newtonsoft.Json;
using StudyCase.DTO;

namespace StudyCase.Consumer
{
    class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        static void Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(configurator =>
            {
                configurator.Host("localhost", "/", hostConfigurator =>
                {
                    hostConfigurator.Username("guest");
                    hostConfigurator.Password("guest");
                });
                configurator.ReceiveEndpoint("testQueue", endpointConfigurator =>
                {
                    endpointConfigurator.Handler<Message>(Handler);
                });
            });
            busControl.Start();

            Console.ReadKey();
        }
        private static Task Handler(ConsumeContext<Message> context)
        {
            return _httpClient.PostAsync("https://localhost:5001/api/Queue", new StringContent(JsonConvert.SerializeObject(context.Message), Encoding.UTF8, "application/json"));
          //  return Console.Out.WriteLineAsync($"Received : {context.Message.Title}");
        }
    }
}
