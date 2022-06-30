namespace FeedbackManagementPlatform.Models.FeedbackForms;

public class FeedbackFormModel
{
    public Guid Id { get; set; }

    public Guid FromId { get; set; }
    public string FromUsername { get; set; }

    public string ToUserName { get; set; }

    public string? Strengths { get; set; }

    public string? Improvements { get; set; }

    public string? Other { get; set; }

    public DateTime Date { get; set; }
}