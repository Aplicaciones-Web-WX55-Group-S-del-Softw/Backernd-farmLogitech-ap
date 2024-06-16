using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Commands;
using Backend_farmlogitech.Profiles.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Backend_farmlogitech.Profiles.Application.Internal.CommandServices
{
    public class ProfileCommandService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileCommandService(IProfileRepository profileRepository, IHttpContextAccessor httpContextAccessor)
        {
            _profileRepository = profileRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Profile> Handle(CreateProfileCommand command)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var profile = new Profile(command)
            {
                id = int.Parse(userId)
            };

            await _profileRepository.AddAsync(profile);

            return profile;
        }
    }
}