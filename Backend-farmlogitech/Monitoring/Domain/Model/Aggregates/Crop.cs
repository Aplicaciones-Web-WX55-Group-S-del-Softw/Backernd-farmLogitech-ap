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

    public int Id { get; private  set; }
    public string Type { get; set; }
    public string PlantingDate { get; set; }
    public int Quantity { get; set; }
    public int ShedId { get; set; }

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
    //todo implement delete and read
    public void Delete(DeleteCropCommand command)
    {
        this.Id = command.Id; 
        this.Type = command.Type;
        this.PlantingDate = command.PlantingDate;
        this.Quantity = command.Quantity;
        this.ShedId = command.ShedId;
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
    