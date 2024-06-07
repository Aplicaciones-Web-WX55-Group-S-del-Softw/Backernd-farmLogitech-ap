namespace Backend_farmlogitech.Farms.Interfaces.REST.Resources.Farm;

public record CreateFarmResource(int Id,string FarmName, string Location, string Type, string Infrastructure, string Certificate, string Product);