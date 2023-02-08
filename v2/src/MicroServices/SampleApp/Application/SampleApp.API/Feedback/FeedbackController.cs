using Microsoft.AspNetCore.Mvc;
using SampleApp.API.Feedback.Models;
using SampleApp.Business.Service.Feedback;
using Shared.ApplicationWebBase.BaseComponents;

namespace SampleApp.API.Feedback;

[Route("feedback")]
public class FeedbackController : SharedSecureController
{
    private readonly IFeedbackService feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        this.feedbackService = feedbackService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(GiveFeedbackRequest model)
    {
        await feedbackService.GiveFeedback(model.Email, model.Name, model.Message);
        return SuccessResponse();
    }
}
