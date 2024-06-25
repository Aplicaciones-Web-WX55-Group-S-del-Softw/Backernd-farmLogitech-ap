namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Crops;

public record CreateCropResource(string Type, string PlantingDate, int Quantity, int ShedId);