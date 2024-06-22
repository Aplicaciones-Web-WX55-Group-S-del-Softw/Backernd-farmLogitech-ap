using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Tasks;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Tasks;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Tasks;

public static class CreateTaskCommandFromResourceAssembler
{
    public static CreateTaskCommand ToCommandFromResource(CreateTaskResource resource)
    {
        return new CreateTaskCommand(resource.id, resource.collaboratorId, resource.farmerId, resource.description);
    }
}