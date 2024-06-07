using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Animals;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Animals;


public class ReadAnimalCommandFromResourceAssembler
{
    public static ReadAnimalCommand ToCommandFromResource(ReadAnimalResource resource)
    {
        return new ReadAnimalCommand(resource.Id, resource.Name, resource.Age, resource.Location,
            resource.HealthState, resource.ShedId); 
    }
}