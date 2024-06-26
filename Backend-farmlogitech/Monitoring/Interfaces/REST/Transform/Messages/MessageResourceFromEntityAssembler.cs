using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Messages;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Messages
{
    public static class MessageResourceFromEntityAssembler
    {
        public static MessageResource ToResourceFromEntity(Message entity)
        {
            return new MessageResource(entity.Id, entity.CollaboratorId, entity.Description);
        }
    }
}