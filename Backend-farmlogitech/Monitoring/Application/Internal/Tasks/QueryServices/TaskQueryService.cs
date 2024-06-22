using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Task;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Tasks;
using Backend_farmlogitech.Monitoring.Domain.Services.Tasks;
using AggregatesTask = Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Tasks.QueryServices;

public class TaskQueryService (ITaskRepository taskRepository): ITaskQueryService
{
    public async Task<AggregatesTask> Handle(GetTaskByIdQuery query)
    {
        return await taskRepository.FindByIdAsync(query.id);
    }
    public async Task<IEnumerable<AggregatesTask>> Handle(GetAllTasksByCollaboratorId query)
    {
        return await taskRepository.FindByCollaboratorIdAsync(query.collaboratorId);
    }
}