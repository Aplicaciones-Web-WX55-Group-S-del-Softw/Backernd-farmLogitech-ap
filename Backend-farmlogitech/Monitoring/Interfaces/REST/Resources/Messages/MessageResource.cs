namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Messages;

public record MessageResource(int id, string description, int collaboratorId, int farmerId, int transmitterId);