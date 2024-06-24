namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

public record CreateMessageCommand(string description, int collaboratorId, int farmerId);