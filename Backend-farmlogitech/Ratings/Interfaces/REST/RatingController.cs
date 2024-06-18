using System.Net.Mime;
using backend_famLogitech_aw.Ratings.Interfaces.REST.Resources;
using backend_famLogitech_aw.Ratings.Interfaces.REST.Transform;
using Backend_farmlogitech.Ratings.Domain.Model.Queries;
using Backend_farmlogitech.Ratings.Domain.Services;
using Backend_farmlogitech.Ratings.Interfaces.REST.Resources;
using Backend_farmlogitech.Ratings.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.Ratings.Interfaces.REST;
[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class FarmController : ControllerBase
{
    /*
    private readonly IRatingCommandService ratingCommandService;
    private readonly IRatingQueryService ratingQueryService;

    public FarmController(IRatingCommandService ratingCommandService, IRatingQueryService ratingQueryService)
    {
        this.ratingCommandService = ratingCommandService;
        this.ratingQueryService = ratingQueryService;
    }

    [HttpPost("createRating")]
    public async Task<ActionResult> CreateRating([FromBody] CreateRatingResource resource)
    {
        var createRatingCommand = CreateRatingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await ratingCommandService.Handle(createRatingCommand);
        return CreatedAtAction(nameof(GetRatingById), new { id = result.Id }, RatingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRatingById(int id)
        {
            var getRatingByIdQuery = new GetRatingByIdQuery(id);
            var result = await ratingQueryService.Handle(getRatingByIdQuery);
            var resource = RatingResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetAllRatingsByUserId(int userId)
        {
            var getAllRatingsByUserIdQuery = new GetRatingByUserIdQuery(userId);
            var result = await ratingQueryService.Handle(getAllRatingsByUserIdQuery);
            var resources = result.Select(RatingResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllRatings()
        {
            var getAllRatings = new GetAllRatingQuery();
            var result = await ratingQueryService.Handle(getAllRatings);
            var resources = result.Select(RatingResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRating(int id, [FromBody] UpdateRatingResource resource)
        {
            var updateRatingCommand = UpdateRatingCommandFromResourceAssembler.ToCommandFromResource(resource);
            updateRatingCommand = updateRatingCommand with { Id = id };
            var result = await ratingCommandService.Handle(updateRatingCommand);
            return Ok(RatingResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        
        */
        
    }
    

