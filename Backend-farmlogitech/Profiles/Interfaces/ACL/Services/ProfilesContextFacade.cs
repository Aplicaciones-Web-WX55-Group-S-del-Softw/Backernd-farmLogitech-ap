using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Commands;
using Backend_farmlogitech.Profiles.Domain.Model.Queries;
using Backend_farmlogitech.Profiles.Domain.Services;

namespace Backend_farmlogitech.Profiles.Interfaces.ACL.Services
{
    public class ProfilesContextFacade : IProfilesContextFacade
    {
        private readonly IProfileCommandService _profileCommandService;
        private readonly IProfileQueryService _profileQueryService;

        public ProfilesContextFacade(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
        {
            _profileCommandService = profileCommandService;
            _profileQueryService = profileQueryService;
        }

        public async Task<int> CreateProfile(string name, string email, string direction, string documentNumber, string documentType, int userId)
        {
            var createProfileCommand = new CreateProfileCommand(name, email, direction, documentNumber, documentType, userId);
            var profile = await _profileCommandService.Handle(createProfileCommand);
            return profile?.id ?? 0;
        }

        public async Task<Profile?> FetchProfileById(int id)
        {
            var getProfileByProfileIdQuery = new GetProfileByProfileIdQuery(id);
            var profile = await _profileQueryService.Handle(getProfileByProfileIdQuery);
            return profile;
        }
    }
}