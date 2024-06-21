using System.Net.Mime;
using Backend_farmlogitech.IAM.Domain.Model.Queries;
using Backend_farmlogitech.IAM.Domain.Services;
using Backend_farmlogitech.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Backend_farmlogitech.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.IAM.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(IUserQueryService userQueryService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user is null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}