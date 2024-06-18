using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;

namespace Backend_farmlogitech.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}