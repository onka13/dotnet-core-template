using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Hosting;

namespace CoreTemplate.Application.WorkerService.Workers
{
    /// <summary>
    /// Sample background service
    /// </summary>
    public class Worker0 : BackgroundService
    {
        /// <summary>
        /// Autofac component to resolve services.
        /// </summary>
        private readonly IComponentContext _componentContext;

        public Worker0(IComponentContext context)
        {
            _componentContext = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {            
            while (!stoppingToken.IsCancellationRequested)
            {
                //var xxxBusinessLogic = _componentContext.Resolve<IxxxBusinessLogic>();
                //await xxxBusinessLogic.DoWork();
                await Task.Delay(60000, stoppingToken); // wait 1 min
            }
        }
    }
}
