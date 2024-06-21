using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;
using Backend_farmlogitech.Monitoring.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;
using backend_famLogitech_aw.Shared.Domain.Repositories;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Messages.CommandServices
{
    public class MessageCommandService : IMessageCommandService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageCommandService(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Message> Handle(CreateMessageCommand command)
        {
            var message = new Message(command);
            await _messageRepository.AddAsync(message);
            await _unitOfWork.CompleteAsync();
            return message;
        }
    }
}