namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Messages;

public record UpdateMessageResource(int Id, int CollaboratorId, string Description);