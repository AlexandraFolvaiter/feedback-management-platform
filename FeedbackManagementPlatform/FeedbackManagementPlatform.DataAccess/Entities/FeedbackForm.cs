namespace FeedbackManagementPlatform.DataAccess.Entities;

public class FeedbackForm
{
    public Guid Id { get; set; }

    public Guid FromId { get; set; }

    public Guid ToId { get; set; }

    public string? Strengths { get; set; }

    public string? Improvements { get; set; }

    public string? Other { get; set; }

    public DateTime Date { get; set; }

    public FeedbackForm()
    {
        Id = Guid.NewGuid();
        Date = DateTime.Now;
    }
}