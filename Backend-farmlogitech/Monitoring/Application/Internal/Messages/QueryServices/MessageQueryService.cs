using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Message;
using Backend_farmlogitech.Monitoring.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Messages.QueryServices
{
    public class MessageQueryService : IMessageQueryService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageQueryService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message> Handle(GetMessageByIdAndUserId query)
        {
            return await _messageRepository.GetByIdAsync(query.messageId);
        }

        public async Task<IEnumerable<Message>> Handle(GetAllMessagesByCollaboratorId query)
        {
            return await _messageRepository.FindAllByCollaboratorId(query.collaboratorId);
        }

        public async Task<IEnumerable<Message>> Handle(GetAllMessagesByCollaboratorIdAndFarmerId query)
        {
            return await _messageRepository.FindAllByCollaboratorIdAndFarmerId(query.userId, query.transmitterId);
        }
    }
}