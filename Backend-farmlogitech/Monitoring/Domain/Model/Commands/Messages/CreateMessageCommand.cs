namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

public record CreateMessageCommand(int id, int collaboratorId, string description, int farmerId, int transmitterId);