using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Task = System.Threading.Tasks.Task;

namespace Backend_farmlogitech.Monitoring.Domain.Repositories.Crops;

public interface ICropRepository : IBaseRepository<Crop>
{
    Task<IEnumerable<Crop>> FindByAllCropAsync();

    Task<Crop> FindByIdx(int id); 
    
    Task DeleteAsync(Crop crop);
}