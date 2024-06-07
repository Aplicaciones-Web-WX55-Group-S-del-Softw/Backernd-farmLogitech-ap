namespace Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;

public record CreateFarmCommand(int Id,string FarmName, string Location, string Type, string Infrastructure, string Certificate, string Product);

