namespace Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;

public record UpdateFarmCommand(string FarmName, string Location, string Type, string Infrastructure, string Certificate, string Product, string Services, string Status, string Image, string Price, string Surface, string Highlights);
