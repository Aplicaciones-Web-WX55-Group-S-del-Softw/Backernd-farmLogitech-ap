using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Message;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Messages;

public interface IMessageQueryService
{
    Task<Message> Handle(GetMessageByIdQuery query);
    Task<Message> Handle(GetMessageByIdAndUserIdQuery query);
    Task<IEnumerable<Message>> Handle(GetAllMessagesByCollaboratorId query);
    Task<IEnumerable<Message>> Handle(GetAllMessageQuery query);
}