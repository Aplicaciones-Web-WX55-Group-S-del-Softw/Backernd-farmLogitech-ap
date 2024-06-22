using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Message;
using Backend_farmlogitech.Monitoring.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Messages.QueryServices;

public class MessageQueryService (IMessageRepository messageRepository) : IMessageQueryService
{
    public async Task<IEnumerable<Message>> Handle(GetAllMessagesByCollaboratorId query)
    {
        return await messageRepository.FindAllByCollaboratorId(query.collaboratorId);
    }

    public async Task<IEnumerable<Message>> Handle(GetAllMessagesByCollaboratorIdAndFarmerId query)
    {
        return await messageRepository.FindAllByCollaboratorIdAndFarmerId(query.userId, query.transmitterId);
    }

    public async Task<Message> Handle(GetMessageByIdAndUserId query)
    {
        var userAuth= User.UserAuthenticate.UserId;
        return await messageRepository.FindByIdAsync(userAuth);
    }
}
