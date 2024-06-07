using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Shed;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Shed;

public static class ShedResourceFromEntityAssembler
{
    public static ShedResource ToResourceFromEntity(Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Shed entity)
    {
        return new ShedResource(entity.Id, entity. FarmId,  entity. Location,  entity. Type);
    }
}