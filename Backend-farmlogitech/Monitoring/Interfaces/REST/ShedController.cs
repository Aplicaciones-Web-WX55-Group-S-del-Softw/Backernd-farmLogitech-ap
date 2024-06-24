using System.Net.Mime;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Shed;
using Backend_farmlogitech.Monitoring.Domain.Services.Sheds;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Shed;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Shed;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ShedController : ControllerBase
{
    private readonly IShedQueryService _shedQueryService;
    private readonly IShedCommandService _shedCommandService;
    
    public ShedController(IShedQueryService shedQueryService, IShedCommandService shedCommandService)
    {
        this._shedQueryService = shedQueryService;
        this._shedCommandService = shedCommandService;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateShedSource([FromBody] CreateShedResource resource)
    {
        var createShedCommand = CreateShedCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _shedCommandService.Handle(createShedCommand);
        return CreatedAtAction(nameof(GetShedById), new { id = result.Id },
            ShedResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetShedById(int id)
    {
        var getFarmByIdQuery = new GetShedByIdQuery(id);
        var result = await _shedQueryService.Handle(getFarmByIdQuery);
        var resource = ShedResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpGet("all")]
    public async Task<ActionResult> GetAllSheds()
    {        
        var getAllShed = new GetAllShedQuery();
        var result = await _shedQueryService.Handle(getAllShed);
        var resources = result.Select(ShedResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}