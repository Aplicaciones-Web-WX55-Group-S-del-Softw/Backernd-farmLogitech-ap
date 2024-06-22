using System.Security;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Message;
using Backend_farmlogitech.Monitoring.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;
using System.Security.Claims;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Messages.QueryServices
{
    public class MessageQueryService : IMessageQueryService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessageQueryService(IMessageRepository messageRepository, IHttpContextAccessor httpContextAccessor)
        {
            _messageRepository = messageRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Message>> Handle(GetAllMessagesByCollaboratorId query)
        {
            return await _messageRepository.FindAllByCollaboratorId(query.collaboratorId);
        }

        public async Task<IEnumerable<Message>> Handle(GetAllMessagesByCollaboratorIdAndFarmerId query)
        {
            var authenticatedUserId = GetAuthenticatedUserId();
            var userRole = GetUserRole();

            IEnumerable<Message> messages;
            if (userRole == "FarmWorker") 
            {
                messages = await _messageRepository.FindAllMessageByCollaboratorIdAndTransmitterIdNot(authenticatedUserId, authenticatedUserId);
            } 
            else if (userRole == "Farmer") 
            {
                messages = await _messageRepository.FindAllMessageByFarmerIdAndTransmitterIdNot(authenticatedUserId, authenticatedUserId);
            } 
            else 
            {
                throw new SecurityException("Authenticated user is neither collaborator nor farmer");
            }

            return messages;
        }

        public async Task<Message> Handle(GetMessageByIdAndUserId query)
        {
            var message = await _messageRepository.FindByIdAsync(query.messageId);
            if (message == null)
            {
                throw new ArgumentException("Message with provided ID does not exist");
            }

            var authenticatedUserId = GetAuthenticatedUserId();
            if (authenticatedUserId == message.collaboratorId || authenticatedUserId == message.farmerId)
            {
                return message;
            }
            else
            {
                throw new SecurityException("Authenticated user is neither collaborator nor farmer");
            }
        }

        private long GetAuthenticatedUserId()
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

            if (!long.TryParse(userIdClaim, out long userId))
            {
                throw new Exception("User ID claim is not a valid integer");
            }

            return userId;
        }

        private string GetUserRole()
        {
            var userClaims = _httpContextAccessor.HttpContext?.User;
            var userRoleClaim = userClaims.FindFirst(ClaimTypes.Role)?.Value;
            return userRoleClaim;
        }
    }
}