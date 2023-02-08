namespace SampleApp.Business.Service.Feedback;

public interface IFeedbackService
{
    Task GiveFeedback(string email, string? name, string message);
}
