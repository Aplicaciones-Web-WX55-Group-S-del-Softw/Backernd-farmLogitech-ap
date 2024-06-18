namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

public record UpdateMessageCommand(int Id, int CollaboratorId, string Description);