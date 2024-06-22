using System;
using System.Threading.Tasks;
using backend_famLogitech_aw.Shared.Domain.Repositories;
using AggregatesTask = Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Tasks;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Tasks;
using Backend_farmlogitech.Monitoring.Domain.Services.Tasks;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;
using static Backend_farmlogitech.IAM.Domain.Model.Aggregates.User;

namespace Backend_farmlogitech.Monitoring.Application.Internal.CommandServices;

public class TaskCommandService : ITaskCommandService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ITaskRepository taskRepository;
    private readonly IUserRepository userRepository;

    public TaskCommandService(IUnitOfWork unitOfWork, ITaskRepository taskRepository, IUserRepository userRepository)
    {
        this.unitOfWork = unitOfWork;
        this.taskRepository = taskRepository;
        this.userRepository = userRepository;
    }

    public async Task<AggregatesTask> Handle(CreateTaskCommand command)
    {
        var userGlobal = User.UserAuthenticate.UserId;
        var userRole = await userRepository.GetUserRole(userGlobal);
        if (userRole.Role != Role.FARMER)
        {
            throw new Exception("Only users with role FARMER can create a task");
        }

        // Check if the task already exists
        var existingTask = await taskRepository.FindByIdx(command.Id);
        if (existingTask != null)
        {
            throw new Exception("Task with this ID already exists");
        }

        var newTask = new AggregatesTask(command);
        await taskRepository.AddAsync(newTask);
        await unitOfWork.CompleteAsync();
        return newTask;
    }

    public async Task<AggregatesTask> Handle(UpdateTaskCommand command)
    {
        var userGlobal = User.UserAuthenticate.UserId; 
        var taskToUpdate = await taskRepository.FindByIdx(command.Id);
        if (taskToUpdate == null)
            throw new Exception("Task with ID does not exist");
        taskToUpdate.Update(command);
        await unitOfWork.CompleteAsync();
        return taskToUpdate;
    }
}