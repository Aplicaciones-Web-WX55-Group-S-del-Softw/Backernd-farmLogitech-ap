using System.Runtime.InteropServices.JavaScript;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Crops;

public record CreateCropCommand(string Type, string PlantingDate, int Quantity, int ShedId);