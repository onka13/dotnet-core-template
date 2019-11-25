using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreTemplate.Application.WorkerService.Workers
{
    /// <summary>
    /// Sample background service
    /// </summary>
    public class TestWorker1 : BackgroundService
    {
        private readonly ILogger<TestWorker1> _logger;

        public TestWorker1(ILogger<TestWorker1> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
