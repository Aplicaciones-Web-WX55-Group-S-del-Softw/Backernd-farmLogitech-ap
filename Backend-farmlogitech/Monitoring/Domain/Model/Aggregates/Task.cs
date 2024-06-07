using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Task;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

public class Task
{
    public int Id { get; private set; }
    public int CollaboratorId { get; set; }
    public int FarmerId { get; set; }
    public string Description { get; set; }

    protected Task()
    {
        this.Id = 0;
        this.CollaboratorId = 0;
        this.FarmerId = 0;
        this.Description = string.Empty;
    }

    public Task(CreateTaskCommand command)
    {
        this.Id = command.Id;
        this.CollaboratorId = command.CollaboratorId;
        this.FarmerId = command.FarmerId;
        this.Description = command.Description;
    }

    public void Update(UpdateTaskCommand command)
    {
        this.CollaboratorId = command.CollaboratorId;
        this.FarmerId = command.FarmerId;
        this.Description = command.Description;
    }
}