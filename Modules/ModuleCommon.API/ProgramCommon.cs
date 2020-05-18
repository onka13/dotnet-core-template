using CoreCommon.Application.API.Base;
using CoreCommon.Application.API.Helpers;
using CoreCommon.Business.Service.Helpers;
using Microsoft.Extensions.Hosting;

namespace ModuleCommon.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var startup = new StartupCommon();
            ProgramCommon.Main(args, startup);
        }
    }

    /// <summary>
    /// Program
    /// </summary>
    public class ProgramCommon
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args, StartupWebBase startup)
        {
            var hostBuilder = StartupHelper.CreateHostBuilder(args, startup, isWeb: true);
            hostBuilder = StartupWebHelper.ConfigureWebHostDefaults(hostBuilder, startup);
            hostBuilder.Build().Run();
        }
    }
}
