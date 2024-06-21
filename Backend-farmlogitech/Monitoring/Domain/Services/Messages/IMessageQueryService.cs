using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Message;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Messages;

public interface IMessageQueryService
{
    Task<IEnumerable<Message>> Handle(GetAllMessagesByCollaboratorId query);
    Task<IEnumerable<Message>> Handle(GetAllMessagesByCollaboratorIdAndFarmerId query);
    Task<Message> Handle(GetMessageByIdAndUserId query);
}