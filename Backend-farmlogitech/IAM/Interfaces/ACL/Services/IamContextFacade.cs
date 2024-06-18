using Backend_farmlogitech.IAM.Domain.Services;
using Backend_farmlogitech.IAM.Interfaces.ACL;
using Backend_farmlogitech.IAM.Domain.Model.Commands;
using Backend_farmlogitech.IAM.Domain.Model.Queries;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;

namespace Backend_farmlogitech.IAM.Interfaces.ACL.Services;

public class IamContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IIamContextFacade
{
    public async Task<int> CreateUser(string username, string password, Role role)
    {
        var signUpCommand = new SignUpCommand(username, password, role);
        await userCommandService.Handle(signUpCommand);
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<int> FetchUserIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<string> FetchUsernameByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result?.Username ?? string.Empty;
    }
}