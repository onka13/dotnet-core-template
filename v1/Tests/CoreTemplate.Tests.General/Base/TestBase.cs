using CoreCommon.Business.Service.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModuleAccount.IServices;
using ModuleAccount.Models;
using System;
using System.Linq;

namespace CoreTemplate.Tests.General.Base
{
    /// <summary>
    /// Base class for all Tests. 
    /// </summary>
    public class TestBase
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public TestBase()
        {
            Init();
        }

        /// <summary>
        /// Initialize IoC and other settings.
        /// </summary>
        public void Init()
        {
            if (ServiceProvider != null) return;            
            var host = StartupHelper.CreateHostBuilder<Startup>(null).Build();
            ServiceProvider = host.Services;
        }

        /// <summary>
        /// Get service of type T from the ServiceProvider.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        #region " default user "

        /// <summary>
        /// Default user email for using other tests
        /// </summary>
        public static string DefaultEmail = "default@gmail.com";

        /// <summary>
        /// Use a specific user for tests
        /// </summary>
        /// <returns></returns>
        public UserInfo GetUserInfo()
        {
            var userBusiness = Resolve<IUserBusinessLogic>();
            return userBusiness.FindBy(x => x.Email == DefaultEmail).Value.Select(x => new UserInfo
            {
                Id = x.Id,
                Email = x.Email
            }).FirstOrDefault();
        }

        #endregion
    }
}
