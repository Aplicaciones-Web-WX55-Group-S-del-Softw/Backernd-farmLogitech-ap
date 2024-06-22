using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Message;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Messages;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Messages;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces("application/json")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageCommandService _messageCommandService;
        private readonly IMessageQueryService _messageQueryService;

        public MessageController(IMessageCommandService messageCommandService, IMessageQueryService messageQueryService)
        {
            _messageCommandService = messageCommandService;
            _messageQueryService = messageQueryService;
        }

        [HttpPost]
        public async Task<ActionResult<MessageResource>> CreateMessage([FromBody] CreateMessageResource resource)
        {
            var command = CreateMessageCommandFromResourceAssembler.ToCommandFromResource(resource);
            var message = await _messageCommandService.Handle(command);
            var messageResource = MessageResourceFromEntityAssembler.ToResourceFromEntity(message);
            return CreatedAtAction(nameof(GetMessageById), new { messageId = messageResource.id }, messageResource);
        }

        [HttpGet("user")]
        public async Task<ActionResult<List<MessageResource>>> GetAllMessagesByAuthenticatedUser()
        {
            var authenticatedUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var query = new GetAllMessagesByCollaboratorIdAndFarmerId(authenticatedUserId, authenticatedUserId);
            var messages = await _messageQueryService.Handle(query);
            var messageResources = messages.Select(MessageResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(messageResources);
        }

        [HttpGet("message/{messageId}")]
        public async Task<ActionResult<MessageResource>> GetMessageById(int messageId)
        {
            var authenticatedUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var query = new GetMessageByIdAndUserId(messageId, authenticatedUserId);
            var message = await _messageQueryService.Handle(query);
            if (message == null)
            {
                return NotFound($"No message found with ID {messageId}");
            }
            var messageResource = MessageResourceFromEntityAssembler.ToResourceFromEntity(message);
            return Ok(messageResource);
        }

        [HttpGet]
        public async Task<ActionResult<List<MessageResource>>> GetAllMessagesByCollaboratorIdAndFarmerId(int collaboratorId, int farmerId)
        {
            var query = new GetAllMessagesByCollaboratorIdAndFarmerId(collaboratorId, farmerId);
            var messages = await _messageQueryService.Handle(query);
            var messageResources = messages.Select(MessageResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(messageResources);
        }
    }
}