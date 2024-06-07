namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;

public record DeleteAnimalCommand(int Id, string Name, int Age, string Location, string HealthState, int ShedId);