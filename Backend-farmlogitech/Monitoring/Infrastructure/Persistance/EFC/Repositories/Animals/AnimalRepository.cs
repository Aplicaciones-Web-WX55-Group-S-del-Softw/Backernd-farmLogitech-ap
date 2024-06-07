using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Animals;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Backend_farmlogitech.Monitoring.Infrastructure.Persistance.EFC.Repositories.Animals;

public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
{
    public AnimalRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Animal>> FindByAllAnimalsAsync()
    {
        return await Context.Set<Animal>().ToListAsync();
    }

    public async Task<Animal> FindByShedId(int shedId)
    {
        return await Context.Set<Animal>().FirstOrDefaultAsync(f => f.ShedId == shedId);
    }
    
    public async Task<Animal> FindByIdAsync(int id)
    {
        return await Context.Set<Animal>().FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task DeleteAsync(Animal animal)
    {
        Context.Set<Animal>().Remove(animal);
        await Context.SaveChangesAsync();
    }
}