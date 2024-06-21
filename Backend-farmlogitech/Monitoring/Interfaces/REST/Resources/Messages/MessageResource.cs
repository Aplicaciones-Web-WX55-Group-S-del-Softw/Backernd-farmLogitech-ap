namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Messages;

public record MessageResource(long id, string description, long collaboratorId, long farmerId, long transmitterId);