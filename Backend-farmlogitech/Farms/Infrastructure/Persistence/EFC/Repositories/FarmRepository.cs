using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Farms.Domain.Model.Aggregates;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.Farms.Infrastructure.Persistence.EFC.Repositories;

public class FarmRepository : BaseRepository<Farm>, IFarmRepository
{
    /*min 1:36:15*/
    public FarmRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Farm>> FindByLocationAsync(string location)
    {
        return await Context.Set<Farm>().Where(f => f.Location == location).ToListAsync();
    }

    public async Task<IEnumerable<Farm>> FindByAllFarmAsync()
    {
        return await Context.Set<Farm>().ToListAsync();
    }

    public Task<Farm?> FindByUserId(int userId)
    {
        return Context.Set<Farm>().FirstOrDefaultAsync(f => Equals(f.UserId, userId));
    }
    
    public Task<Farm?> GetFarmById(int id)
    {
        return Context.Set<Farm>().FirstOrDefaultAsync(f => Equals(f.Id, id));
    }
   

   
}  