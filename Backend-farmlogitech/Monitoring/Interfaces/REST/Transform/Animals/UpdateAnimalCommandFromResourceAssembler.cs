using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Animals;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Animals;

public class UpdateAnimalCommandFromResourceAssembler
{
    public static UpdateAnimalCommand ToCommandFromResource(UpdateAnimalResource resource)
    {
        return new UpdateAnimalCommand(resource.Id, resource.Name, resource.Age, resource.Location,
            resource.HealthState, resource.ShedId, resource.FarmId, resource.UserId);
    } 
}