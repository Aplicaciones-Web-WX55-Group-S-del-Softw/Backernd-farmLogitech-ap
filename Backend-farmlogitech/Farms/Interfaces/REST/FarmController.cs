using System.Net.Mime;
using System.Security.Claims;
using Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;
using Backend_farmlogitech.Farms.Domain.Model.Queries.Farm;
using Backend_farmlogitech.Farms.Domain.Services;
using Backend_farmlogitech.Farms.Interfaces.REST.Resources.Farm;
using Backend_farmlogitech.Farms.Interfaces.REST.Transform.Farm;
using Backend_farmlogitech.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.Farms.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class FarmController(IFarmCommandService farmCommandService, IFarmQueryService farmQueryService)
    : ControllerBase
{

    
    [HttpPost]
    public async Task<ActionResult> CreateFarmSource([FromBody] CreateFarmResource resource)
    {
        var createFarmCommand = CreateFarmCommandFromResourceAssembler.ToCommandFromResource(resource);
    
 

        var result = await farmCommandService.Handle(createFarmCommand);
        return CreatedAtAction(nameof(GetFarmById), new { id = result.Id },
            FarmResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    
    
    
    
    
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetFarmById(int id)
    {
        var getFarmByIdQuery = new GetFarmByIdQuery(id);
        var result = await farmQueryService.Handle(getFarmByIdQuery);
        var resource = FarmResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    
    [HttpGet("location/{location}")]
    public async Task<ActionResult> GetAllFarmByLocation(string location)
    {
        var getAllFarmByLocationQuery = new GetFarmByLocationQuery(location);
        var result = await farmQueryService.Handle(getAllFarmByLocationQuery);
        var resources = result.Select(FarmResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("profiles/{profileid}")]
    public async Task<ActionResult> GetFarmByProfileId(int profileid)
    {
        var getAllFarmByLocationQuery = new GetFarmByUserIdQuery(profileid);
        var result = await farmQueryService.Handle(getAllFarmByLocationQuery);
        if (result == null)
        {
            return NotFound(); // Devuelve un 404 si no se encuentra la granja
        }
        var resource = FarmResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("farm/all")]
    public async Task<ActionResult> GetAllFarms()
    {        
        var getAllFarms = new GetAllFarmQuery();
        var result = await farmQueryService.Handle(getAllFarms);
        var resources = result.Select(FarmResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateFarm( [FromBody] UpdateFarmResource resource)
    {
        var updateFarmCommand = UpdateFarmCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await farmCommandService.Handle(updateFarmCommand);
        return Ok(FarmResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    
  
}
