using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

public class Message
{
    protected Message(int id, int collaboratorId, string description, int farmerId, int transmitterId)
    {
        this.id = id;
        this.collaboratorId = collaboratorId;
        this.description = description;
        this.farmerId = farmerId;
        this.transmitterId = transmitterId;
    }
    
    private string _description;
    private int _collaboratorId;
    private int _farmerId;

    public int id { get; private set; }

    public int collaboratorId 
    { 
        get { return _collaboratorId; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Collaborator ID must be a positive number");
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
                throw new Exception("Description cannot be null or empty");
            }
            _description = value;
        }
    }

    public int farmerId 
    { 
        get { return _farmerId; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Farmer ID must be a positive number");
            }
            _farmerId = value;
        }
    }

    public int transmitterId { get; set; }
    

    public Message(CreateMessageCommand command)
    {
        this.collaboratorId = command.collaboratorId;
        this.description = command.description;
        this.farmerId = command.farmerId;
    }
}
