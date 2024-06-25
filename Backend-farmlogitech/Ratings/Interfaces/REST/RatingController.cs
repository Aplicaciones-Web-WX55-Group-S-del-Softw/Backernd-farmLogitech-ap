using System.Net.Mime;
using backend_famLogitech.Ratings.Interfaces.REST.Resources;
using Backend_famLogitech.Ratings.Interfaces.REST.Transform;
using Backend_farmlogitech.Ratings.Interfaces.REST.Resources;
using Backend_farmlogitech.Ratings.Interfaces.REST.Transform;
using Backend_farmlogitech.Ratings.Domain.Model.Queries;
using Backend_farmlogitech.Ratings.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.Ratings.Interfaces.REST;
[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RatingController : ControllerBase
{
    private readonly IRatingCommandService _ratingCommandService;
    private readonly IRatingQueryService _ratingQueryService;

    public RatingController(IRatingCommandService ratingCommandService, IRatingQueryService ratingQueryService)
    {
        this._ratingCommandService = ratingCommandService;
        this._ratingQueryService = ratingQueryService;
    }

    [HttpPost("createRating")]
    public async Task<ActionResult> CreateRating([FromBody] CreateRatingResource resource)
    {
        var createRatingCommand = CreateRatingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _ratingCommandService.Handle(createRatingCommand);
        return CreatedAtAction(nameof(GetRatingById), new { id = result.Id }, RatingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRatingById(int id)
        {
            var getRatingByIdQuery = new GetRatingByIdQuery(id);
            var result = await _ratingQueryService.Handle(getRatingByIdQuery);
            var resource = RatingResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetAllRatingsByUserId(int userId)
        {
            var getAllRatingsByUserIdQuery = new GetRatingByUserIdQuery(userId);
            var result = await _ratingQueryService.Handle(getAllRatingsByUserIdQuery);
            if (result == null)
            {
                return NotFound($"No ratings found for user with ID {userId}");
            }
            var resources = RatingResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resources);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllRatings()
        {
            var getAllRatings = new GetAllRatingQuery();
            var result = await _ratingQueryService.Handle(getAllRatings);
            var resources = result.Select(RatingResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRating(int id, [FromBody] UpdateRatingResource resource)
        {
            var updateRatingCommand = UpdateRatingCommandFromResourceAssembler.ToCommandFromResource(resource);
            updateRatingCommand = updateRatingCommand with { Id = id };
            var result = await _ratingCommandService.Handle(updateRatingCommand);
            return Ok(RatingResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        
    }
    

