using CoreCommon.Business.Service.Helpers;
using Microsoft.Extensions.Hosting;

namespace ModuleServiceBus
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
