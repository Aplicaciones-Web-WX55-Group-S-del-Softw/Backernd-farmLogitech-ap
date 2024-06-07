namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Crops;

public record ReadCropResource(int Id, string Type, string PlantingDate, int Quantity, int ShedId); 