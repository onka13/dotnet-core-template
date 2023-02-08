using SampleApp.Domain.Feedback;

namespace SampleApp.Business.Service.Feedback;

public class FeedbackService : IFeedbackService
{
    private readonly IFeedbackRepository feedbackRepository;

    public FeedbackService(IFeedbackRepository feedbackRepository)
    {
        this.feedbackRepository = feedbackRepository;
    }

    public async Task GiveFeedback(string email, string? name, string message)
    {
        await feedbackRepository.Add(new FeedbackEntity
        {
            Email = email,
            Name = name,
            Message = message,
        });
    }
}
