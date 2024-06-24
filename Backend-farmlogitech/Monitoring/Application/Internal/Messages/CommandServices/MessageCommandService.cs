using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;
using Backend_farmlogitech.Monitoring.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;
using Backend_farmlogitech.Profiles.Domain.Repositories;


namespace Backend_farmlogitech.Monitoring.Application.Internal.Messages.CommandServices
{
    public class MessageCommandService : IMessageCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFarmRepository _farmRepository;

        public MessageCommandService(IUnitOfWork unitOfWork, IMessageRepository messageRepository, IUserRepository userRepository, IEmployeeRepository employeeRepository, IFarmRepository farmRepository)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _farmRepository = farmRepository;
        }

        public async Task<Message> Handle(CreateMessageCommand command)
        {
            // Get the globally authenticated user ID
            var userGlobal = User.UserAuthenticate.UserId;

            // Get the user role from the user ID
            var userRole = await _userRepository.GetUserRole(userGlobal);

            
            // Check if the user has already created a message. If they have, throw an exception
            var existingMessages = await _messageRepository.FindAllMessageByCollaboratorIdAndTransmitterId(userGlobal, userGlobal);           
            if (existingMessages.Any())
            {
                throw new Exception("User has already created a message");
            }

            // Create a new message with the provided command
            var messageNew = new Message(command);
            
            // Assign the user ID to the new message
            messageNew.transmitterId = userGlobal;
            
            if (userRole.Role == Role.FARMER)
            {
                var employee = await _employeeRepository.FindById(command.collaboratorId);
                if (employee == null)
                {
                    throw new Exception("No employee found with the provided collaboratorId");
                }
                
                var collab = await _userRepository.FindByUsernameAsync(employee.Username);
                if (collab == null)
                {
                    throw new Exception("No user found with the provided username");
                }
                
                var collabid = collab.Id;
                // messageNew.collaboratorId = collabid;
                messageNew.farmerId = userGlobal;
            }
            
            if (userRole.Role == Role.FARMWORKER)
            { 
                var emplo = await _employeeRepository.FindById(userGlobal);
                var farmid = emplo.FarmId;

                var farm = await _farmRepository.FindByIdAsync(farmid);
                var userid = farm.UserId;

                var boss = await _userRepository.FindByIdAndRoleAsync(userid, Role.FARMER);
                
                messageNew.collaboratorId = userGlobal;
                messageNew.farmerId = boss.Id;
            }

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