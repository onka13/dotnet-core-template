﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoreCommon.Business.Service.IoC;
using CoreTemplate.Application.API.Components.Middlewares;
using CoreTemplate.Business.Service.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;

namespace CoreTemplate.Application.API
{
    /// <summary>
    /// Startup of the project. Register types for IoC, configure host features.
    /// </summary>
    public class Startup : CoreCommon.Business.Service.IoC.StartupBase
    {
        /// <summary>
        /// Configure application
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always
            });

            /*
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/html";

                    await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                    await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    // Use exceptionHandlerPathFeature to process the exception (for example, 
                    // logging), but do NOT expose sensitive error information directly to 
                    // the client.

                    if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                    {
                        await context.Response.WriteAsync("File error thrown!<br><br>\r\n");
                    }

                    await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
                    await context.Response.WriteAsync("</body></html>\r\n");
                    await context.Response.WriteAsync(new string(' ', 512)); // IE padding
                });
            });*/

            app.UseMiddleware<HttpHeadersMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Add services
        /// </summary>
        /// <param name="services"></param>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            var mvcBuilder = services.AddControllers().AddControllersAsServices();

            // register api modules routes
            var apiModuleFiles = Directory.GetFiles(AppContext.BaseDirectory, "ApiModule*.dll").ToList();
            foreach (var apiFilePath in apiModuleFiles)
            {
                mvcBuilder.AddApplicationPart(System.Reflection.Assembly.LoadFrom(apiFilePath));
            }
            
            services.AddAuthorization(options =>
            {
                //options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = Environment.IsDevelopment() ? StatusCodes.Status307TemporaryRedirect : StatusCodes.Status308PermanentRedirect;
                //options.HttpsPort = Environment.IsDevelopment() ? 44308 : 443;
            });            
            DependencyManager.ConfigureServices(Configuration, services);
        }

        /// <summary>
        /// Register types
        /// </summary>
        /// <param name="builder"></param>
        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            DependencyManager.ConfigureContainer(builder);
            DependencyHelper.RegisterCommonTypes(builder, typeof(Program));            
        }
    }
}
