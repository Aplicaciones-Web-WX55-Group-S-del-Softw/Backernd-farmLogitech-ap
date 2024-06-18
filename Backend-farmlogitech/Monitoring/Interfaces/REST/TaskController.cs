using System.Net.Mime;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Tasks;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Tasks;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Task;
using Backend_farmlogitech.Monitoring.Domain.Services.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class TaskController : ControllerBase
    {
        private readonly ITaskCommandService taskCommandService;
        private readonly ITaskQueryService taskQueryService;

        public TaskController(ITaskCommandService taskCommandService, ITaskQueryService taskQueryService)
        {
            this.taskCommandService = taskCommandService;
            this.taskQueryService = taskQueryService;
        }

        [HttpPost("createTask")]
        public async Task<ActionResult> CreateTask([FromBody] CreateTaskResource resource)
        {
            var createTaskCommand = CreateTaskCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await taskCommandService.Handle(createTaskCommand);
            return CreatedAtAction(nameof(GetTaskById), new { id = result.Id }, TaskResourceFromEntityAssembler.ToResourceFromEntity(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTaskById(int id)
        {
            var getTaskByIdQuery = new GetTaskByIdQuery(id);
            var result = await taskQueryService.Handle(getTaskByIdQuery);
            var resource = TaskResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }

        [HttpGet("collaborator/{collaboratorId}")]
        public async Task<ActionResult> GetAllTasksByCollaboratorId(int collaboratorId)
        {
            var getAllTasksByCollaboratorIdQuery = new GetAllTasksByCollaboratorId(collaboratorId);
            var result = await taskQueryService.Handle(getAllTasksByCollaboratorIdQuery);
            var resources = result.Select(TaskResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpGet("collaborator/{collaboratorId}/farmer/{farmerId}")]
        public async Task<ActionResult> GetAllTasksByCollaboratorIdAndFarmerId(int collaboratorId, int farmerId)
        {
            var getAllTasksByCollaboratorIdAndFarmerIdQuery = new GetAllTasksByCollaboratorIdAndFarmerId(collaboratorId, farmerId);
            var result = await taskQueryService.Handle(getAllTasksByCollaboratorIdAndFarmerIdQuery);
            var resources = result.Select(TaskResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, [FromBody] UpdateTaskResource resource)
        {
            var updateTaskCommand = UpdateTaskCommandFromResourceAssembler.ToCommandFromResource(resource);
            updateTaskCommand = updateTaskCommand with { Id = id };
            var result = await taskCommandService.Handle(updateTaskCommand);
            return Ok(TaskResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
    }
}