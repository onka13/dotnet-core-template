using System.ComponentModel.DataAnnotations;

namespace SampleApp.API.Feedback.Models;

public class GiveFeedbackRequest
{
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Message { get; set; } = string.Empty;
}
