namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Animals;

public record UpdateAnimalResource(int Id, string Name, int Age, string Location, string HealthState, int ShedId, int FarmId, int UserId);