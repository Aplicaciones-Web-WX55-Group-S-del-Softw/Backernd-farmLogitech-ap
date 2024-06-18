using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Messages;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Messages;

public static class UpdateMessageCommandFromResourceAssembler
{
    public static UpdateMessageCommand ToCommandFromResource(UpdateMessageResource resource)
    {
        return new UpdateMessageCommand(resource.Id, resource.CollaboratorId, resource.Description);
    }
}
