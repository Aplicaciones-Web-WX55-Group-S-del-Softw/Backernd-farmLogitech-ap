namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

public record CreateMessageCommand(int Id, int CollaboratorId, string Description);