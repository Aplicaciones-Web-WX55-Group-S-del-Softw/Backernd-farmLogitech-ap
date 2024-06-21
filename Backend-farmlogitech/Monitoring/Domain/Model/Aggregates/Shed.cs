using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Sheds;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

public class Shed
{
    public int Id { get; private set; }
    
    private string _type;
    private string _location;
    private int _farmId;

    public string Type
    {
        get { return _type; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Type cannot be null or empty.");
            }
            _type = value;
        }
    }

    public string Location
    {
        get { return _location; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Location cannot be null or empty.");
            }
            _location = value;
        }
    }

    public int FarmId
    {
        get { return _farmId; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("FarmId must be greater than 0.");
            }
            _farmId = value;
        }
    }

    protected Shed()
    {
        this.Id = 0;
        this.FarmId = 0;
        this.Location = string.Empty;
        this.Type = string.Empty;
    }

    public Shed(CreateShedCommand command)
    {
        this.Id = command.Id;
        this.FarmId = command.FarmId;
        this.Location = command.Location;
        this.Type = command.Type;
    }
}