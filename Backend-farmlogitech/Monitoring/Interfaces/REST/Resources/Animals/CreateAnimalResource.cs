namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Animals;

public record CreateAnimalResource(string Name, int Age, string Location, string HealthState, int ShedId);