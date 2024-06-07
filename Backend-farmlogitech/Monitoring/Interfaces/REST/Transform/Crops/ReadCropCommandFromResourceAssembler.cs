using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Crops;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Crops;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Crops;

public class ReadCropCommandFromResourceAssembler
{
    public static ReadCropCommand ToCommandFromResource(ReadCropResource resource)
    {
        return new ReadCropCommand(resource.Id, resource.Type, resource.PlantingDate, resource.Quantity, resource.ShedId);
    }
}