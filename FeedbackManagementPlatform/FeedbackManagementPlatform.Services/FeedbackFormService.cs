using FeedbackManagementPlatform.DataAccess;
using FeedbackManagementPlatform.DataAccess.Contexts;
using FeedbackManagementPlatform.DataAccess.Entities;
using FeedbackManagementPlatform.Models.FeedbackForms;
using FeedbackManagementPlatform.Services.Contracts;

namespace FeedbackManagementPlatform.Services;

public class FeedbackFormService: IFeedbackFormService
{
    private readonly DatabaseContext _dbContext;
    private readonly IUserService _userService;

    public FeedbackFormService(DatabaseContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _dbContext.SeedFeedbackForms();
        _userService = userService;
    }

    public async Task<IEnumerable<FeedbackFormModel>> GetAllFeedbackFormsAsManager(Guid userId)
    {
        var users = await _userService.GetAllUsersByManager(userId);
        var usersIds = users.ToList().Select(u => u.Id);

        var allUsers = await _userService.GetAllUsers();

        var result = _dbContext
            .Forms
            .Where(f => usersIds.Contains(f.ToId))
            .ToList()
            .Select(f => new FeedbackFormModel
                {
                    Id = f.Id,
                    FromId = f.FromId,
                    FromUsername = allUsers.FirstOrDefault(u => u.Id == f.FromId)!.DisplayName,
                    ToUserName = users.FirstOrDefault(u => u.Id == f.ToId)!.DisplayName,
                    Strengths = f.Strengths,
                    Improvements = f.Improvements,
                    Other = f.Other,
                    Date = f.Date
                });

        return result;
    }

    public async Task<IEnumerable<FeedbackFormModel>> GetAllCreatedFeedbackFormsByUserId(Guid userId)
    {
        var users = await _userService.GetAllUsers();
        var result = _dbContext.Forms
            .Where(f => f.FromId == userId)
            .ToList()
            .Select(f => new FeedbackFormModel
            {
                Id = f.Id,
                FromId = f.FromId,
                FromUsername = users.FirstOrDefault(u => u.Id == f.FromId)!.DisplayName,
                ToUserName = users.FirstOrDefault(u => u.Id == f.ToId)!.DisplayName,
                Strengths = f.Strengths,
                Improvements = f.Improvements,
                Other = f.Other,
                Date = f.Date
            });

        return result;
    }

    public async Task<FeedbackFormModel> GetFeedbackFormById(Guid formId)
    {
        var users = await _userService.GetAllUsers();

        var entity = _dbContext.Forms.FirstOrDefault(f => f.Id == formId);
        var model = new FeedbackFormModel
        {
            Id = entity.Id,
            FromId = entity.FromId,
            FromUsername = users.FirstOrDefault(u => u.Id == entity.FromId)!.DisplayName,
            ToUserName = users.FirstOrDefault(u => u.Id == entity.ToId)!.DisplayName,
            Strengths = entity.Strengths,
            Improvements = entity.Improvements,
            Other = entity.Other,
            Date = entity.Date
        };

        return model;
    }

    public void SaveFeedbackForm(FeedbackFormCreateModel model)
    {
        var entity = new FeedbackForm
        {
            FromId = model.FromId,
            ToId = model.ToId,
            Strengths = model.Strengths,
            Improvements = model.Improvements,
            Other = model.Other,
        };

        _dbContext.Forms.Add(entity);
        _dbContext.SaveChanges();
    }
}