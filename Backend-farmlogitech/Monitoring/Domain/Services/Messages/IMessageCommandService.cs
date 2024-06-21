using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Messages;

public interface IMessageCommandService
{
    Task<Message> Handle(CreateMessageCommand command);
}