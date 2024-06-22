namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Tasks;

public record UpdateTaskCommand(int id, int collaboratorId, int farmerId, string description);