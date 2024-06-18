namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Tasks;

public record UpdateTaskResource(int Id, int CollaboratorId, int FarmerId, string Description);