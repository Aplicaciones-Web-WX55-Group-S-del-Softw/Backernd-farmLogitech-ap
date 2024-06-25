using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Tasks;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Tasks;
using Backend_farmlogitech.Monitoring.Domain.Services.Tasks;
using AggregatesTask = Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Tasks.CommandServices;

public class TaskCommandService (IUnitOfWork unitOfWork, ITaskRepository taskRepository): ITaskCommandService
{
    public async Task<AggregatesTask> Handle(CreateTaskCommand command)
    {
        var taskNew = await taskRepository.FindByIdx(command.Id);
        if (taskNew != null)
            throw new System.Exception("Task with ID already exists");
        taskNew = new AggregatesTask(command);
        await taskRepository.AddAsync(taskNew);
        await unitOfWork.CompleteAsync();
        return taskNew;
    }

    public async Task<AggregatesTask> Handle(UpdateTaskCommand command)
    {
        var taskToUpdate = await taskRepository.FindByIdx(command.Id);
        if (taskToUpdate == null)
            throw new System.Exception("Task with ID does not exist");
        taskToUpdate.Update(command);
        await unitOfWork.CompleteAsync();
        return taskToUpdate;
    }
}