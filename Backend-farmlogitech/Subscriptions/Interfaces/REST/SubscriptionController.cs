using System.Net.Mime;
using Backend_farmlogitech.Subscriptions.Domain.Model.Queries;
using Backend_farmlogitech.Subscriptions.Domain.Services;
using Backend_farmlogitech.Subscriptions.Interfaces.REST.Resources;
using Backend_farmlogitech.Subscriptions.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.Subscriptions.Interfaces.REST;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SubscriptionController : ControllerBase
{
    private ISubscriptionCommandService _subscriptionCommandService;
    private ISubscriptionQueryService _subscriptionQueryService;

    public SubscriptionController(ISubscriptionCommandService subscriptionCommandService, ISubscriptionQueryService subscriptionQueryService)
    {
        _subscriptionCommandService = subscriptionCommandService;
        _subscriptionQueryService = subscriptionQueryService;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateSubscription([FromBody] CreateSubscriptionResource resource)
    {
        var createSubscriptionCommand = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _subscriptionCommandService.Handle(createSubscriptionCommand);
        return CreatedAtAction(nameof(GetSubscriptionById), new { id = result.Id },
            SubscriptionResourceFromEntityAssembler.ToResource(result));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetSubscriptionById(int id)
    {
        var getSubscriptionByIdQuery = new GetSubscriptionByIdQuery(id);
        var result = await _subscriptionQueryService.Handle(getSubscriptionByIdQuery);
        var resource = SubscriptionResourceFromEntityAssembler.ToResource(result);
        return Ok(resource);
    }
    
    [HttpGet("profile/{profileId}")]
    public async Task<ActionResult> GetSubscriptionByProfileId(int profileId)
    {
        var getSubscriptionByProfileIdQuery = new GetSubscriptionByProfileIdQuery(profileId);
        var result = await _subscriptionQueryService.Handle(getSubscriptionByProfileIdQuery);
        var resource = SubscriptionResourceFromEntityAssembler.ToResource(result ?? throw new InvalidOperationException());
        return Ok(resource);
    }
    
    [HttpGet("all")]
    public async Task<ActionResult> GetAllSubscriptions()
    {
        var getAllSubscriptionsQuery = new GetAllSubscriptionsQuery();
        var result = await _subscriptionQueryService.Handle(getAllSubscriptionsQuery);
        var resources = result.Select(SubscriptionResourceFromEntityAssembler.ToResource);
        return Ok(resources);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateFarm( [FromBody] UpdateSubscriptionResource resource)
    {
        var updateFarmCommand = UpdateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _subscriptionCommandService.Handle(updateFarmCommand);
        return Ok(SubscriptionResourceFromEntityAssembler.ToResource(result));
    }
}

