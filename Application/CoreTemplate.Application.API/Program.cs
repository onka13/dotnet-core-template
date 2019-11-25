using CoreCommon.Business.Service.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModuleCommon.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CoreTemplate.Application.API
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create host
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var startup = new Startup();
            return StartupHelper.CreateHostBuilder(args, startup, isWeb: true)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder
                        // configure services here because of that we do not use UseStartup<Startup>()
                        .ConfigureServices(services =>
                        {
                            startup.ConfigureServices(services);
                        })
                        .Configure(app =>
                        {
                            var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
                            var config = app.ApplicationServices.GetRequiredService<Microsoft.Extensions.Configuration.IConfiguration>();
                            startup.Configure(app, env);
                        })
                        ;
                    });
        }
    }
}
