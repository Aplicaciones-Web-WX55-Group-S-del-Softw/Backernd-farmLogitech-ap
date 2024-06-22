namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Messages;

public record CreateMessageResource(string description, int collaboratorId, int farmerId, int transmitterId);