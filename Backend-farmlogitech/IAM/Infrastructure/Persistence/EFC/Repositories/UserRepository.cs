using Backend_farmlogitech.IAM.Domain.Repositories;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }

    public Task<User?> GetUserRole(int id)
    {
        return Context.Set<User>().FirstOrDefaultAsync(user => user.Id == id);
    }
}