namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Crops;

public record ReadCropCommand(int Id, string Type, string PlantingDate, int Quantity, int ShedId);