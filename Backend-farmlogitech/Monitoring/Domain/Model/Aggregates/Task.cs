using System;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Tasks;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

public class Task
{
    protected Task(int id, int collaboratorId, int farmerId, string description)
    {
        this.id = 0;
        this.collaboratorId = 0;
        this.farmerId = 0;
        this.description = string.Empty;
    }
    
    private string _description;
    private int _collaboratorId;

    public int id { get; private set; }
    public int farmerId { get; set; }

    public int collaboratorId
    {
        get { return _collaboratorId; }
        set
        {
            if (value == 0)
            {
                throw new Exception("Collaborator ID cannot be null.");
            }
            _collaboratorId = value;
        }
    }

    public string description
    {
        get { return _description; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Description cannot be null or empty.");
            }
            if (value.Length > 30)
            {
                throw new Exception("Description is too long. It cannot be more than 30 characters.");
            }
            _description = value;
        }
    }
    
    public Task(CreateTaskCommand command)
    {
        this.id = command.Id;
        this.collaboratorId = command.CollaboratorId;
        this.farmerId = command.FarmerId;
        this.description = command.Description;
    }

    public void Update(UpdateTaskCommand command)
    {
        this.collaboratorId = command.CollaboratorId;
        this.farmerId = command.FarmerId;
        this.description = command.Description;
    }
}