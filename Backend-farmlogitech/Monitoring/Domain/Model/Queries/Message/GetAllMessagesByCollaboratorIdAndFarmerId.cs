namespace Backend_farmlogitech.Monitoring.Domain.Model.Queries.Message;

public record GetAllMessagesByCollaboratorIdAndFarmerId(int userId, int transmitterId);