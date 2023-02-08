using DotNetCommon.Application.APIBase.Base;
using DotNetCommon.Infrastructure.Exceptions;
using DotNetTemplate.Business.Service.User;

namespace DotNetTemplate.Tests.User;

public class UnitTest1 : TestBase<Startup>
{
    [InlineData("test@test.com", "1")]
    [Theory]
    public async Task LoginTest(string email, string password)
    {
        var userBusinessLogic = Resolve<IUserService>();
        var response = await userBusinessLogic.Login(email, password).CatchAsync();
        Assert.False(response.Success);
    }
}