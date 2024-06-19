using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Message;
using Backend_farmlogitech.Monitoring.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Messages.QueryServices;

public class MessageQueryService (IMessageRepository messageRepository): IMessageQueryService
{
    public async Task<Message> Handle(GetMessageByIdQuery query)
    {
        return await messageRepository.FindByIdx(query.Id);
    }

    public async Task<IEnumerable<Message>> Handle(GetAllMessagesByCollaboratorId query)
    {
        return await messageRepository.FindByCollaboratorId(query.CollaboratorId);
    }
    
    public async Task<Message> Handle(GetMessageByIdAndUserIdQuery query)
    {
        return await messageRepository.FindByIdAndUserId(query.Id, query.UserId);
    }

    public async Task<IEnumerable<Message>> Handle(GetAllMessageQuery query)
    {
        return await messageRepository.FindByAllMessage();
    }
}
