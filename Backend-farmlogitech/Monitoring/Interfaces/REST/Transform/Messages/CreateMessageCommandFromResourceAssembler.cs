using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Messages;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Messages;

public static class CreateMessageCommandFromResourceAssembler
{
    public static CreateMessageCommand ToCommandFromResource(CreateMessageResource resource)
    {
        return new CreateMessageCommand(resource.description, resource.collaboratorId, resource.farmerId, resource.transmitterId);
    }
}
