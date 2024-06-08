namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Tasks;

public record TaskResource(int Id, int CollaboratorId, int FarmerId, string Description);