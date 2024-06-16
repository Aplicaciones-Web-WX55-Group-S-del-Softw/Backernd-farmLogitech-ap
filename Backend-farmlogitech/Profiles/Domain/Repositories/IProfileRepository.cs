using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<IEnumerable<Profile>> FindAllProfiles();
    Task<Profile?> FindByIdAsync(long id);
}