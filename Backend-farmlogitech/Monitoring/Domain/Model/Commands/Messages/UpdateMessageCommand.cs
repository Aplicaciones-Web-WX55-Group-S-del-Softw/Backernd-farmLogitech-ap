namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

public record UpdateMessageCommand(int id, int collaboratorId, string description, int farmerId, int transmitterId);