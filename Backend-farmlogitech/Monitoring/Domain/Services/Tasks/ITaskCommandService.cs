using AggregatesTask = Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Tasks;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Tasks;

public interface ITaskCommandService
{
    Task<AggregatesTask> Handle(CreateTaskCommand command);
    
    Task<AggregatesTask> Handle(UpdateTaskCommand command);
}