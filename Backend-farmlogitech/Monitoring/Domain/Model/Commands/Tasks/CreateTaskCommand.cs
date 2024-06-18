namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Tasks;

public record CreateTaskCommand(int Id, int CollaboratorId, int FarmerId, string Description);