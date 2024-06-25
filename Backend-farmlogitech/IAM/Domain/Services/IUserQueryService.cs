using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.Queries;

namespace Backend_farmlogitech.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}