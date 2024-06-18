using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Crops;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

public class Crop
{
    protected Crop(int id, string type, string plantingDate, int quantity, int shedId)
    {
        Id = id;
        Type = type;
        PlantingDate = plantingDate;
        Quantity = quantity;
        ShedId = shedId;
    }

    private string _type;
    private string _plantingDate;
    private int _quantity;
    private int _shedId;

    public int Id { get; private set; }

    public string Type
    {
        get { return _type; }
        set
        {
            if (value != "wheat" && value != "rice" && value != "potato")
            {
                throw new Exception("Type must be either 'wheat', 'rice', or 'potato'.");
            }
            _type = value;
        }
    }

    public string PlantingDate
    {
        get { return _plantingDate; }
        set
        {
            _plantingDate = value;
        }
    }

    public int Quantity
    {
        get { return _quantity; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Quantity must be greater than or equal to 0.");
            }
            _quantity = value;
        }
    }

    public int ShedId
    {
        get { return _shedId; }
        set
        {
            if (value < 1 || value > 3)
            {
                throw new Exception("ShedId must be between 1 and 3.");
            }
            _shedId = value;
        }
    }

    public Crop(CreateCropCommand command)
    {
        this.Id = command.Id; 
        this.Type = command.Type;
        this.PlantingDate = command.PlantingDate;
        this.Quantity = command.Quantity;
        this.ShedId = command.ShedId;
    }

    public void Update(UpdateCropCommand command)
    {
        this.PlantingDate = command.PlantingDate;
        this.Type = command.Type;
        this.Quantity = command.Quantity;
        this.ShedId = command.ShedId;
    }
    
    public void Delete(DeleteCropCommand command)
    {
        
    }
    
    public void Read(ReadCropCommand command)
    {
        this.Id = command.Id; 
        this.Type = command.Type;
        this.PlantingDate = command.PlantingDate;
        this.Quantity = command.Quantity;
        this.ShedId = command.ShedId;
    }
}
    