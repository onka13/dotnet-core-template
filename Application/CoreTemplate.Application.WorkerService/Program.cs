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
            CreateHostBuilder(args).Build().Run();            
        }

        /// <summary>
        /// Creates host
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return StartupHelper.CreateHostBuilder<Startup>(args);
        }
    }
}
