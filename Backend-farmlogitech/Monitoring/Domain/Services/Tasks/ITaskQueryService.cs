using AggregatesTask = Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Task;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Tasks;

public interface ITaskQueryService
{
    Task<AggregatesTask> Handle(GetTaskByIdQuery query);
    Task<IEnumerable<AggregatesTask>> Handle(GetAllTasksByCollaboratorId query);
    
    Task<IEnumerable<AggregatesTask>> Handle(GetAllTasksByCollaboratorIdAndFarmerId query);
}