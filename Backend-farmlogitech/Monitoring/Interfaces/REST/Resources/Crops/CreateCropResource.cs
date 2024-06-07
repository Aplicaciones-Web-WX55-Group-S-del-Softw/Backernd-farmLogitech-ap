namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Crops;

public record CreateCropResource(int Id, string Type, string PlantingDate, int Quantity, int ShedId);