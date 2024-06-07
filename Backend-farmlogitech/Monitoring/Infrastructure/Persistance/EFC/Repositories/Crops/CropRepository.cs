using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Crops;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Backend_farmlogitech.Monitoring.Infrastructure.Persistance.EFC.Repositories.Crops;

public class CropRepository : BaseRepository<Crop>, ICropRepository
{
    public CropRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Crop>> FindByAllCropAsync()
    {
        return await Context.Set<Crop>().ToListAsync();
    }

    public async Task<Crop> FindByIdx(int id)
    {
        return await Context.Set<Crop>().FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task DeleteAsync(Crop crop)
    {
        Context.Set<Crop>().Remove(crop);
        await Context.SaveChangesAsync();
    }
}