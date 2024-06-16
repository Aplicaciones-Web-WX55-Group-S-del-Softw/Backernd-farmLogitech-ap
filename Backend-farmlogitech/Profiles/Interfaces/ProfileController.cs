using System.Net.Mime;
using Backend_farmlogitech.Profiles.Domain.Model.Queries;
using Backend_farmlogitech.Profiles.Domain.Services;
using Backend_farmlogitech.Profiles.Interfaces.REST.Resources;
using Backend_farmlogitech.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.Profiles.Interfaces
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProfileController : ControllerBase
    {
        private IProfileQueryService _profileQueryService;
        private IProfileCommandService _profileCommandService;

        public ProfileController(IProfileQueryService profileQueryService, IProfileCommandService profileCommandService)
        {
            _profileQueryService = profileQueryService;
            _profileCommandService = profileCommandService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProfile([FromBody] CreateProfileResource resource)
        {
            var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommand(resource); 
            var profile = await _profileCommandService.Handle(createProfileCommand);
            return CreatedAtAction(nameof(GetProfileById), new { id = profile.id }, 
                ProfileResourceFromEntityAssembler.ToResource(profile));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProfileById(long id)
        {
            var query = new GetProfileByProfileIdQuery(id);
            var result = await _profileQueryService.Handle(query);
            var resource = ProfileResourceFromEntityAssembler.ToResource(result);
            return Ok(resource);
        }
    }
}