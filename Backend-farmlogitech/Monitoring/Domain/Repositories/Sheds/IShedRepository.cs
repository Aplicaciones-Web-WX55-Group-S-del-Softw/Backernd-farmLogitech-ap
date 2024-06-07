using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Monitoring.Domain.Repositories.Sheds;

public interface IShedRepository: IBaseRepository<Shed>
{
    
    Task<IEnumerable<Shed>> FindByAllShedAsync();
    Task<Shed> FindShedById(int id);

}