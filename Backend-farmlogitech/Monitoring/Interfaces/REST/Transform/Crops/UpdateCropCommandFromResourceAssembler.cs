using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Crops;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Crops;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Crops;

public static class UpdateCropCommandFromResourceAssembler
{
    public static UpdateCropCommand ToCommandFromResource(UpdateCropResource resource)
    {
        return new UpdateCropCommand(resource.Id, resource.Type, resource.PlantingDate, resource.Quantity, resource.ShedId);
    }
}