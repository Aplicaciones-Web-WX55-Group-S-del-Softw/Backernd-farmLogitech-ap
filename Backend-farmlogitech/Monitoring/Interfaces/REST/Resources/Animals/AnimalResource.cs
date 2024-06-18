namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Animals;

public record AnimalResource(int Id, int Age, string Location, int ShedId, string Name, string HealthState, int FarmId, int UserId);