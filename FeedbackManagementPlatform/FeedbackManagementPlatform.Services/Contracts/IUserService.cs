using FeedbackManagementPlatform.Models;

namespace FeedbackManagementPlatform.Services.Contracts;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetAllUsers();
    Task<IEnumerable<UserModel>> GetAllUsersByManager(Guid managerId);
}