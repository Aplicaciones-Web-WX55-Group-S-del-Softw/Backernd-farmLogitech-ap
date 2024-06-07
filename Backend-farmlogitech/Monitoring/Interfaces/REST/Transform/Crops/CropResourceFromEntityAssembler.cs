using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Crops;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Crops;

public static class CropResourceFromEntityAssembler
{
    public static CropResource ToResourceFromEntity(Crop entity)
    {
        return new CropResource(entity.Id, entity.Type, entity.PlantingDate, entity.Quantity, entity.ShedId);
    }
}