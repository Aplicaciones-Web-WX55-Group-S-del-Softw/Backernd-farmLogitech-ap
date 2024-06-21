namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

public record CreateMessageCommand(string description, long collaboratorId, long farmerId, long transmitterId);