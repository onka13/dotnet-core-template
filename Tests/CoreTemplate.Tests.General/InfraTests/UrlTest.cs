using CoreCommon.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace CoreTemplate.Tests.General.InfraTests
{
    /// <summary>
    /// Tests Url helper methods in Infra. 
    /// </summary>
    public class UrlTest
    {
        /// <summary>
        /// Check url response status codes.
        /// </summary>
        [Fact]
        public async void CheckUrls()
        {
            var urls = new Dictionary<string, int> {
                { "http://www.mocky.io/v2/5dcc06e154000064009c207a", 202 },
                {"http://www.mocky.io/v2/5dcc071d54000059009c207c", 503 },
                {"http://www.mocky.io/v2/5dcc071d54000059009c207c?mocky-delay=30s", -1 }, // 503 delay 30 sec
                {"ht tp://google.com", -2 },
                {"http://google.com", 200 }
            };
            foreach (var url in urls)
            {
                var result = await UrlHelper.CheckUrl(url.Key);
                System.Diagnostics.Debug.WriteLine("{0} : {1} - {2}", url, result.Status, result.Reason);
                
                Assert.True(result.Status == url.Value);
            }
        }
    }
}
