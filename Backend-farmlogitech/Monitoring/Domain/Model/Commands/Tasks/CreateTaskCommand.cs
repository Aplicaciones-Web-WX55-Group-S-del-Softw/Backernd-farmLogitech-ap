namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Tasks;

public record CreateTaskCommand(int id, int collaboratorId, int farmerId, string description);