namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Shed;

public record CreateShedResource(int Id, int FarmId, string Location, string Type);