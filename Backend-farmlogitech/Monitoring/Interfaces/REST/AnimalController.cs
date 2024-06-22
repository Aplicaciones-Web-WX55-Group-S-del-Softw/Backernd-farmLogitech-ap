using System.Net.Mime;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Animals;
using Backend_farmlogitech.Monitoring.Domain.Services.Animals;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Resources.Animals;
using Backend_farmlogitech.Monitoring.Interfaces.REST.Transform.Animals;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.Monitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AnimalController : ControllerBase
{
    private IAnimalQueryService _animalQueryService;
    private IAnimalCommandService _animalCommandService;

    public AnimalController(IAnimalQueryService animalQueryService, IAnimalCommandService animalCommandService)
    {
        _animalQueryService = animalQueryService;
        _animalCommandService = animalCommandService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAnimal([FromBody] CreateAnimalResource resource)
    {
        var createAnimalCommand = CreateAnimalCommandFromResourceAssembler.ToCommandFromResource(resource);
        var animal = await _animalCommandService.Handle(createAnimalCommand);
        return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, 
            AnimalResourceFromEntityAssembler.ToResourceFromEntity(animal));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetAnimalById(int id)
    {
        var query = new GetAnimalByIdQuery(id);
        var result = await _animalQueryService.Handle(query);
        var resource = AnimalResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("ShedId/{shedid}")]
    public async Task<ActionResult> GetAnimalByShedId(int shedid)
    {
        var query = new GetAnimalByShedIdQuery(shedid);
        var result = await _animalQueryService.Handle(query);
        var resource = AnimalResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("all")]
    public async Task<ActionResult> GetAllAnimals()
    {
        var query = new GetAllAnimalsQuery();
        var result = await _animalQueryService.Handle(query);
        var resources = result.Select(AnimalResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAnimal( [FromBody] UpdateAnimalResource resource)
    {
        var updateAnimalcommand = UpdateAnimalCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _animalCommandService.Handle(updateAnimalcommand);
        return Ok(AnimalResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAnimal(int id)
    {
        var deleteAnimalCommand = new DeleteAnimalCommand(id);
        var result = await _animalCommandService.Handle(deleteAnimalCommand);
        return Ok(AnimalResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
}