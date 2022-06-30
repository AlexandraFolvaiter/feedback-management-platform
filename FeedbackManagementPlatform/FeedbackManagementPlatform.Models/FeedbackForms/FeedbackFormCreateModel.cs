namespace FeedbackManagementPlatform.Models.FeedbackForms;

public class FeedbackFormCreateModel
{
    public Guid FromId { get; set; }

    public Guid ToId { get; set; }

    public string? Strengths { get; set; }

    public string? Improvements { get; set; }

    public string? Other { get; set; }
}