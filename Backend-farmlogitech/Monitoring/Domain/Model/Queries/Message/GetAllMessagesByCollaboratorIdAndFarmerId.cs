namespace Backend_farmlogitech.Monitoring.Domain.Model.Queries.Message;

public record GetAllMessagesByCollaboratorIdAndFarmerId(long userId, long transmitterId);