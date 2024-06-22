using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Tasks;
using AggregatesTask = Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Tasks;

public static class TaskResourceFromEntityAssembler
{
    public static TaskResource ToResourceFromEntity(AggregatesTask entity)
    {
        return new TaskResource(entity.id, entity.collaboratorId, entity.farmerId, entity.description);
    }
}