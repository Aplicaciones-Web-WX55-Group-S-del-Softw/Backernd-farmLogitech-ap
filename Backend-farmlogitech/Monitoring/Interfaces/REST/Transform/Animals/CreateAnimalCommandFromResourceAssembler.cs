using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Animals;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Animals;

public class CreateAnimalCommandFromResourceAssembler
{
    public static CreateAnimalCommand ToCommandFromResource(CreateAnimalResource resource)
    {
        return new CreateAnimalCommand(resource.Id, resource.Name, resource.Age, resource.Location, resource.HealthState, resource.ShedId);
    }
}