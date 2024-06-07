namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Crops;

public record DeleteCropResource(int Id, string Type, string PlantingDate, int Quantity, int ShedId); 