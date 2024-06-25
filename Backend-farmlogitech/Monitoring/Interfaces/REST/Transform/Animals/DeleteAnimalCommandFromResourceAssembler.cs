using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Animals;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Animals;

public class DeleteAnimalCommandFromResourceAssembler
{
    public static DeleteAnimalCommand ToCommandFromResource(DeleteAnimalResource resource)
    {
        return new DeleteAnimalCommand(resource.Id); 
    }
}