using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using YogurtTheBot.Game.Server.RabbitMq;

namespace YogurtTheBot.Alice.Services
{
    public class RabbitReceiver : BackgroundService
    {
        private readonly IRabbitService _rabbitService;

        public RabbitReceiver(IRabbitService rabbitService)
        {
            _rabbitService = rabbitService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _rabbitService.Listen();
            
            return Task.CompletedTask;
        }
    }
}