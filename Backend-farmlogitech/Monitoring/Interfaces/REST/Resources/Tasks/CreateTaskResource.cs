namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Tasks;

public record CreateTaskResource(int id, int collaboratorId, int farmerId, string description);