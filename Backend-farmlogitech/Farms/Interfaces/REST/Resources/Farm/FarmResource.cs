namespace Backend_farmlogitech.Farms.Interfaces.REST.Resources.Farm;
//parece un struct 
public record FarmResource(int Id,string FarmName, string Location, string Type, string Infrastructure, string Certificate, string Product);