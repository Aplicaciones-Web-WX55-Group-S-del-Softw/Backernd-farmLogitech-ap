using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Sheds;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.Monitoring.Infrastructure.Persistance.EFC.Repositories.Sheds;

public class  ShedRepository : BaseRepository<Shed>, IShedRepository
{
    public ShedRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Shed>> FindByAllShedAsync()
    {
        return await Context.Set<Shed>().ToListAsync();
    }

    public async Task<Shed> FindShedById(int id)
    {
        return await Context.Set<Shed>().FirstOrDefaultAsync(f => f.Id == id);
    }
}