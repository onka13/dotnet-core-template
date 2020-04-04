using CoreCommon.Application.API.Base;
using CoreCommon.Application.API.Helpers;
using CoreCommon.Business.Service.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ModuleCommon.Application.API
{
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
