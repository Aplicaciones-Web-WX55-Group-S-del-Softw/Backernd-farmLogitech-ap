namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Crops;

public record CropResource(int Id, string Type, string PlantingDate, int Quantity, int ShedId, int FarmId, int UserId);