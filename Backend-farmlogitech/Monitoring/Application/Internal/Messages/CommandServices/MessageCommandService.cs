using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;
using Backend_farmlogitech.Monitoring.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;


namespace Backend_farmlogitech.Monitoring.Application.Internal.Messages.CommandServices
{
    public class MessageCommandService : IMessageCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public MessageCommandService(IUnitOfWork unitOfWork, IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public async Task<Message> Handle(CreateMessageCommand command)
        {
            // Get the globally authenticated user ID
            var userGlobal = User.UserAuthenticate.UserId;

            // Get the user role from the user ID
            var userRole = await _userRepository.GetUserRole(userGlobal);

            // Check if the user role is not TRANSMITTER. If it's not, throw an exception
            if (userRole.Role != Role.FARMER)
            {
                throw new Exception("Only users with role TRANSMITTER can create a message");
            }

            // Check if the user has already created a message. If they have, throw an exception
            var existingMessage = await _messageRepository.GetMessageByUserId(userGlobal);
            if (existingMessage != null)
            {
                throw new Exception("User has already created a message");
            }

            // Create a new message with the provided command
            var messageNew = new Message(command);

            // Assign the user ID to the new message
            messageNew.transmitterId = userGlobal;

            // Add the new message to the repository
            await _messageRepository.AddAsync(messageNew);

            // Complete the unit of work transaction
            await _unitOfWork.CompleteAsync();

            // Return the new message
            return messageNew;
        }
    }
}