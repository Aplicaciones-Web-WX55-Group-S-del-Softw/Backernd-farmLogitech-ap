using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;
using Backend_farmlogitech.Monitoring.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Messages.CommandServices;

public class MessageCommandService (IUnitOfWork unitOfWork, IMessageRepository messageRepository): IMessageCommandService
{
    public async Task<Message> Handle(CreateMessageCommand command)
    {
        var messageNew = await messageRepository.FindByIdx(command.Id);
        if (messageNew != null)
            throw new Exception("Message with ID already exists");
        messageNew = new Message(command);
        await messageRepository.AddAsync(messageNew);
        await unitOfWork.CompleteAsync();
        return messageNew;
    }

    public async Task<Message> Handle(UpdateMessageCommand command)
    {
        var messageToUpdate = await messageRepository.FindByIdx(command.Id);
        if (messageToUpdate == null)
            throw new Exception("Message with ID does not exist");
        messageToUpdate.Update(command);
        await unitOfWork.CompleteAsync();
        return messageToUpdate;
    }
}
