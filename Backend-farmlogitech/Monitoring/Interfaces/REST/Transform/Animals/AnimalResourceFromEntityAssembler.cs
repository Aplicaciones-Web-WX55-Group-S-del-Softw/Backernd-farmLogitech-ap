using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Animals;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Animals;

public class AnimalResourceFromEntityAssembler
{
    public static AnimalResource ToResourceFromEntity(Animal entity)
    {
        return new AnimalResource(entity.Id, entity.Age, entity.Location, entity.ShedId, entity.Name, entity.HealthState);
    }
}