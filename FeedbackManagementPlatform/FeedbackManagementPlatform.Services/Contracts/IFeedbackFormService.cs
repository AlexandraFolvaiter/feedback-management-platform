using FeedbackManagementPlatform.Models.FeedbackForms;

namespace FeedbackManagementPlatform.Services.Contracts;

public interface IFeedbackFormService
{
    Task<IEnumerable<FeedbackFormModel>> GetAllFeedbackFormsAsManager(Guid userId);

    Task<IEnumerable<FeedbackFormModel>> GetAllCreatedFeedbackFormsByUserId(Guid userId);

    Task<FeedbackFormModel> GetFeedbackFormById(Guid formId);

    void SaveFeedbackForm(FeedbackFormCreateModel model);
}