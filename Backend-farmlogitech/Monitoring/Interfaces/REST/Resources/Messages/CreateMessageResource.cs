namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Messages;

public record CreateMessageResource(string description, long collaboratorId, long farmerId, long transmitterId);