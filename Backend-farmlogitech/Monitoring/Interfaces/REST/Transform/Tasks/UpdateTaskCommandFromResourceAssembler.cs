using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Tasks;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Tasks;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Tasks;

public static class UpdateTaskCommandFromResourceAssembler
{
    public static UpdateTaskCommand ToCommandFromResource(UpdateTaskResource resource)
    {
        return new UpdateTaskCommand(resource.id, resource.collaboratorId, resource.farmerId, resource.description);
    }
}