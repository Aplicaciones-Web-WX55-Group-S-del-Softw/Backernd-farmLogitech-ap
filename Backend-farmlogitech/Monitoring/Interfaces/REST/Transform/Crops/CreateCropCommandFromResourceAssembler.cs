using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Crops;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Crops;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Crops;

public static class CreateCropCommandFromResourceAssembler
{
    public static CreateCropCommand ToCommandFromResource( CreateCropResource resource)
    {
        return new CreateCropCommand(resource.Id, resource.Type, resource.PlantingDate, resource.Quantity, resource.ShedId, resource.FarmId, resource.UserId);
    }
}