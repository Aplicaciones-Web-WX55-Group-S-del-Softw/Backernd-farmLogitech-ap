using System.Net.Mime;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Messages;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Messages;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Message;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class MessageController : ControllerBase
    {
        private readonly IMessageCommandService messageCommandService;
        private readonly IMessageQueryService messageQueryService;
        
        public MessageController(IMessageCommandService messageCommandService, IMessageQueryService messageQueryService)
        {
            this.messageCommandService = messageCommandService;
            this.messageQueryService = messageQueryService;
        }

        [HttpPost("createMessage")]
        public async Task<ActionResult> CreateMessage([FromBody] CreateMessageResource resource)
        {
            var createMessageCommand = CreateMessageCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await messageCommandService.Handle(createMessageCommand);
            return CreatedAtAction(nameof(GetMessageById), new { id = result.Id }, MessageResourceFromEntityAssembler.ToResourceFromEntity(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMessageById(int id)
        {
            var getMessageByIdQuery = new GetMessageByIdQuery(id);
            var result = await messageQueryService.Handle(getMessageByIdQuery);
            var resource = MessageResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }

        [HttpGet("collaborator/{collaboratorId}")]
        public async Task<ActionResult> GetAllMessagesByCollaboratorId(int collaboratorId)
        {
            var getAllMessagesByCollaboratorIdQuery = new GetAllMessagesByCollaboratorId(collaboratorId);
            var result = await messageQueryService.Handle(getAllMessagesByCollaboratorIdQuery);
            var resources = result.Select(MessageResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllMessages()
        {
            var getAllMessagesQuery = new GetAllMessageQuery();
            var result = await messageQueryService.Handle(getAllMessagesQuery);
            var resources = result.Select(MessageResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMessage(int id, [FromBody] UpdateMessageResource resource)
        {
            var updateMessageCommand = UpdateMessageCommandFromResourceAssembler.ToCommandFromResource(resource);
            updateMessageCommand = updateMessageCommand with { Id = id };
            var result = await messageCommandService.Handle(updateMessageCommand);
            return Ok(MessageResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
    }
}