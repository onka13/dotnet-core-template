using CoreCommon.Business.Service.Helpers;
using Microsoft.Extensions.Hosting;

namespace CoreTemplate.Application.WorkerService
{
    /// <summary>
    /// Program main
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        public static void Main(string[] args)
        {
            StartupHelper.CreateHostBuilder<Startup>(args).Build().Run();
        }
    }
}
