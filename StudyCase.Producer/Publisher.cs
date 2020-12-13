using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using StudyCase.DTO;

namespace StudyCase.Producer2
{
    internal class Publisher : IHostedService
    {
        private readonly IConfiguration _configuration;
        private readonly IBusControl _busControl;
        private Timer _timer;
        private readonly int _interval;

        public Publisher(IConfiguration configuration, IBusControl busControl)
        {
            _configuration = configuration;
            _busControl = busControl;
            _interval = int.Parse(_configuration["TimeInterval"]);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(PublishMessage, null, 0, _interval);
            return Task.Delay(-1, cancellationToken);
        }

        private void PublishMessage(object? state)
        {
            
            _busControl.Publish(new Message()
            {
                Id = Guid.NewGuid(),
                Title = "Communication Request Started"
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}