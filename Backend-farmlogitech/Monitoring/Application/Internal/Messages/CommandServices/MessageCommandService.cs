using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessageCommandService(IMessageRepository messageRepository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetAuthenticatedUserId()
        {
            var userClaims = _httpContextAccessor.HttpContext?.User;
            if (userClaims == null || !userClaims.Identity.IsAuthenticated)
            {
                throw new Exception("User is not authenticated");
            }

            var userIdClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                throw new Exception("User ID claim is missing");
            }

            if (!int.TryParse(userIdClaim, out int userId))
            {
                throw new Exception("User ID claim is not a valid integer");
            }

            return userId;
        }

        public async Task<Message> Handle(CreateMessageCommand command)
        {
            var userId = GetAuthenticatedUserId();

            var message = new Message(command);
            message.transmitterId = userId;
            await _messageRepository.AddAsync(message);
            await _unitOfWork.CompleteAsync();
            return message;
        }
    }
}