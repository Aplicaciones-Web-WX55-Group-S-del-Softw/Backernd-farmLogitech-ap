namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Tasks;

public record UpdateTaskCommand(int Id, int CollaboratorId, int FarmerId, string Description);