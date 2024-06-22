namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Tasks;

public record TaskResource(int id, int collaboratorId, int farmerId, string description);