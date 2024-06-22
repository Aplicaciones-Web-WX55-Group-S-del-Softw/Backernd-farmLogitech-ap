using Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;
using Microsoft.IdentityModel.Tokens;

namespace Backend_farmlogitech.Farms.Domain.Model.Aggregates;

public class Farm
{
    
    public int UserId { get; set; }

    public int Id { get; private set; }
    public string FarmName { get; set; }
    public string Location { get; set; }
    public string Type { get; set; }
    public string Infrastructure { get; set; }
    public string Services { get; set; }
    public string Status { get; set; }
    public string Certificate { get; set; }

    public string Image { get; set; }
    public string Price { get; set; }
    public string Surface { get; set; }
    public string Product { get; set; }
    
    public string Highlights { get; set; }

    

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
        if(string.IsNullOrEmpty(command.FarmName) || string.IsNullOrEmpty(command.Location) || string.IsNullOrEmpty(command.Type) || string.IsNullOrEmpty(command.Infrastructure) || string.IsNullOrEmpty(command.Certificate) || string.IsNullOrEmpty(command.Product) || string.IsNullOrEmpty(command.Services) || string.IsNullOrEmpty(command.Status) || string.IsNullOrEmpty(command.Image) || string.IsNullOrEmpty(command.Price) || string.IsNullOrEmpty(command.Surface) || string.IsNullOrEmpty(command.Highlights))
        {
            throw new ArgumentException("None of the properties can be null or empty");
        }
    
        this.FarmName = command.FarmName;
        this.Location = command.Location;
        this.Type = command.Type;
        this.Infrastructure = command.Infrastructure;
        this.Certificate = command.Certificate;
        this.Product = command.Product;
        this.Services = command.Services;
        this.Status = command.Status;
        this.Image = command.Image;
        this.Price = command.Price;
        this.Surface = command.Surface;
        this.Highlights = command.Highlights;
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