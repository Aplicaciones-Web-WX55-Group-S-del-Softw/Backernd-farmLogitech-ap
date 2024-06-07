using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Sheds;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

public class Shed
{
    public int Id { get; private set; }
    public string Type { get; set; }
    public string Location { get; set; }
    public int FarmId { get; set; }
    
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