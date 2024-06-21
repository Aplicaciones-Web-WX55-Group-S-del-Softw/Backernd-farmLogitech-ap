using System.Net.Mime;
using Backend_farmlogitech.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Backend_farmlogitech.Profiles.Domain.Model.Queries;
using Backend_farmlogitech.Profiles.Domain.Services;
using Backend_farmlogitech.Profiles.Interfaces.REST.Resources;
using Backend_farmlogitech.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.Profiles.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
   // [Authorize]

    public class EmployeeController : ControllerBase
    {
        private IEmployeeQueryService _employeeQueryService;
        private IEmployeeCommandService _employeeCommandService;

        public EmployeeController(IEmployeeQueryService employeeQueryService, IEmployeeCommandService employeeCommandService)
        {
            _employeeQueryService = employeeQueryService;
            _employeeCommandService = employeeCommandService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeResource resource)
        {
            if (string.IsNullOrEmpty(resource.Username) || string.IsNullOrEmpty(resource.Password))
            {
                return BadRequest("Username or password is null or empty");
            }

            var createEmployeeCommand = CreateEmployeeCommandFromResourceAssembler.ToCommand(resource); 
            var employee = await _employeeCommandService.Handle(createEmployeeCommand);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, 
                EmployeeResourceFromEntityAssembler.ToResource(employee));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var query = new GetEmployeeByIdQuery(id);
            var result = await _employeeQueryService.FindById(query);
            if (result == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
            var resource = EmployeeResourceFromEntityAssembler.ToResource(result);
            return Ok(resource);
        }
        
        [HttpGet("all/{farmId}")]
        public async Task<ActionResult> GetAllEmployeesByFarmId(int farmId)
        {
            var query = new GetEmployeesByFarmId(farmId);
            var employees = await _employeeQueryService.FindAllByFarmId(query);
            if (employees == null || !employees.Any())
            {
                return NotFound($"No employees found for farm ID {farmId}.");
            }
            var resources = employees.Select(EmployeeResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }
    }
}