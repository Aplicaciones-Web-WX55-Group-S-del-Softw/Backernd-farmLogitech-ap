using backend_famLogitech_aw.Shared.Domain.Repositories;
using AggregatesTask = Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task;

namespace Backend_farmlogitech.Monitoring.Domain.Repositories.Tasks;

public interface ITaskRepository: IBaseRepository<AggregatesTask>
{
    Task<IEnumerable<AggregatesTask>> FindByCollaboratorIdAsync(int collaboratorId);
    
    Task<AggregatesTask> FindByIdx(int id);
}