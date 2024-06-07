using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Sheds;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Shed;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Shed;

public static class CreateShedCommandFromResourceAssembler
{
    public static CreateShedCommand ToCommandFromResource(CreateShedResource resource)
    {
        return new CreateShedCommand(resource.Id, resource. FarmId,  resource. Location,  resource. Type);;
    }
}