using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Task = System.Threading.Tasks.Task;

namespace Backend_farmlogitech.Monitoring.Domain.Repositories.Animals;

public interface IAnimalRepository : IBaseRepository<Animal>
{
    Task<IEnumerable<Animal>> FindByAllAnimalsAsync();
    Task<Animal> FindByShedId(int shedId);
    
    Task<Animal> FindByIdAsync(int id);
    Task DeleteAsync(Animal animal);
}