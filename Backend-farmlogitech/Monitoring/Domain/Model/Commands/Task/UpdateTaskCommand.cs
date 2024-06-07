namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Task;

public record UpdateTaskCommand(int CollaboratorId, int FarmerId, string Description);