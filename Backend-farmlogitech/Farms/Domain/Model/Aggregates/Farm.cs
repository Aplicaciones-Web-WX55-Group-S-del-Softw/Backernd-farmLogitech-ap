using Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;

namespace Backend_farmlogitech.Farms.Domain.Model.Aggregates;

public class Farm
{
    public int Id { get; private set; }
    public string FarmName { get; set; }
    public string Location { get; set; }
    public string Type { get; set; }
    public string Infrastructure { get; set; }
    public string Certificate { get; set; }
    public string Product { get; set; }

    protected Farm()
    {
        this.Id = 0;
        this.FarmName = string.Empty;
        this.Location = string.Empty;
        this.Type = string.Empty;
        this.Infrastructure = string.Empty;
        this.Certificate = string.Empty;
        this.Product = string.Empty;
    }

    public Farm(CreateFarmCommand command)
    {
        this.Id = command.Id;
        this.FarmName = command.FarmName;
        this.Location = command.Location;
        this.Type = command.Type;
        this.Infrastructure = command.Infrastructure;
        this.Certificate = command.Certificate;
        this.Product = command.Product;
    }
    public void Update(UpdateFarmCommand command)
    {
        this.FarmName = command.FarmName;
        this.Location = command.Location;
        this.Type = command.Type;
        this.Infrastructure = command.Infrastructure;
        this.Certificate = command.Certificate;
        this.Product = command.Product;
    }


}