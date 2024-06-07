namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Sheds;

public record CreateShedCommand(int Id, int FarmId, string Location, string Type);
