namespace Backend_farmlogitech.Farms.Interfaces.REST.Resources.Farm;

public record UpdateFarmResource(int Id,string FarmName, string Location, string Type, string Infrastructure, string Certificate, string Product, string Services, string Status, string Image, string Price, string Surface, string Highlights);