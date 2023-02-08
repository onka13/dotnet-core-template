using DotNetCommon.Application.APIBase.Base;
using DotNetCommon.Infrastructure.Exceptions;
using SampleApp.Business.Service.Feedback;

namespace SampleApp.Tests.User;

public class FeedbackTests : TestBase<Startup>
{
    [InlineData(null, null, null)]
    [Theory]
    public async Task GiveFeedbackTest(string email, string name, string message)
    {
        var feedbackService = Resolve<IFeedbackService>();
        var response = await feedbackService.GiveFeedback(email, name, message).CatchAsync();
        Assert.False(response.Success);
    }
}