using Azure.Identity;
using FeedbackManagementPlatform.DataAccess.Contexts;
using FeedbackManagementPlatform.Models;
using FeedbackManagementPlatform.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Graph;

namespace FeedbackManagementPlatform.Services;

public class UserService : IUserService
{
    private readonly GraphApiConnection _graphApiConnection;

    public UserService(GraphApiConnection graphApiConnection)
    {
        _graphApiConnection = graphApiConnection;
    }

    public async Task<IEnumerable<UserModel>> GetAllUsers()
    {
        var graphClient = _graphApiConnection.CreateGraphServiceClient();

        var users = await graphClient
            .Users
            .Request()
            .Expand(u => u.Manager)
            .GetAsync();

        return users.CurrentPage.Select(u => new UserModel
        {
            Id = Guid.Parse(u.Id), 
            DisplayName = u.DisplayName,
            Email = u.Mail
        });
    }

    public async Task<IEnumerable<UserModel>> GetAllUsersByManager(Guid managerId)
    {
        var graphClient = _graphApiConnection.CreateGraphServiceClient();

        var users = await graphClient
            .Users
            .Request()
            .Expand(u => u.Manager)
            .GetAsync();

        return users.CurrentPage
            .Where(u => u.Manager?.Id == managerId.ToString())
            .ToList()
            .Select(u => new UserModel
                {
                    Id = Guid.Parse(u.Id),
                    DisplayName = u.DisplayName,
                    Email = u.Mail
                });
    }
}