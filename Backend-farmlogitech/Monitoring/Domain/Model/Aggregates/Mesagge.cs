using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

public class Message
{
    public int Id { get; private set; }
    public int CollaboratorId { get; set; }
    public string Description { get; set; }

    protected Message()
    {
        this.Id = 0;
        this.CollaboratorId = 0;
        this.Description = string.Empty;
    }

    public Message(CreateMessageCommand command)
    {
        this.Id = command.Id;
        this.CollaboratorId = command.CollaboratorId;
        this.Description = command.Description;
    }

    public void Update(UpdateMessageCommand command)
    {
        this.CollaboratorId = command.CollaboratorId;
        this.Description = command.Description;
    }
}