using CoreCommon.Data.EntityFrameworkBase.Components;
using CoreTemplate.Tests.General.Base;
using Xunit;

namespace CoreTemplate.Tests.General.Connection
{
    /// <summary>
    /// Basic Sql Server connection tests
    /// </summary>
    public class MssqlTest : TestBase
    {
        /// <summary>
        /// Tests the connection with 'MainConnection' setting which defined in appsettings.json
        /// </summary>
        [Fact]
        public void CheckConnection()
        {
            var dbContext = Resolve<EmptyDbContext>();
            dbContext.SetName("MainConnection");

            var canConnect = dbContext.Database.CanConnect();
            Assert.True(canConnect, "Couldn't connect to sql server");
        }
    }
}
