using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Crops;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Crops;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Crops;

public class DeleteCropCommandFromResourceAssembler
{
    public static DeleteCropCommand ToCommandFromResource(DeleteCropResource resource)
    {
        return new DeleteCropCommand(resource.Id); 
    }
}