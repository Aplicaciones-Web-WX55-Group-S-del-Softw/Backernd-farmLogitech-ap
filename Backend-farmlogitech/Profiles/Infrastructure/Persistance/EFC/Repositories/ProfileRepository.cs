using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.Profiles.Infrastructure.Persistance.EFC.Repositories;

public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
{

    public ProfileRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Profile>> FindAllProfiles()
    {
        return await Context.Set<Profile>().ToListAsync();
    }

    public async Task<Profile?> FindByIdAsync(long id)
    {
        return await Context.Set<Profile>().FirstOrDefaultAsync(f => f.id== id);}
}