using CoreTemplate.Tests.General.Base;
using ModuleAccount.IServices;
using System;
using Xunit;

namespace CoreTemplate.Tests.General.User
{
    /// <summary>
    /// Basic user tests
    /// </summary>
    public class UserAccountTest : TestBase
    {
        /// <summary>
        /// Tests for user registration. Register User -> check user -> delete user
        /// </summary>
        [Fact]
        public void RegisterAndLogin()
        {
            var userBusiness = Resolve<IUserBusinessLogic>();
            var no = DateTime.UtcNow.Ticks;
            var email = $"test{no}@test.com";
            var pass = "123";
            var name = "Test " + no;
            var registerResult = userBusiness.RegisterUser(email, pass, name);
            Assert.True(registerResult.Success, "User couldn't created");
            Assert.NotNull(registerResult.Value);

            var userResult = userBusiness.GetById(registerResult.Value.Id);
            Assert.True(userResult.Success, "User not found");
            Assert.NotNull(userResult.Value);

            var deleteResult = userBusiness.DeleteById(registerResult.Value.Id);
            Assert.True(deleteResult.Success, "User couldn't deleted");
        }
        
        /// <summary>
        /// Simple registration a user
        /// </summary>
        [Fact]
        public void RegisterDefaultAccount()
        {
            var userBusiness = Resolve<IUserBusinessLogic>();
            var pass = "13579";
            var name = "Onur K.";
            var registerResult = userBusiness.RegisterUser(DefaultEmail, pass, name);
            Assert.True(registerResult.Success, "User couldn't created");
        }
    }
}
