using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Queries;
using Backend_farmlogitech.Profiles.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend_farmlogitech.Profiles.Application.Internal.QueryServices
{
    public class ProfileQueryService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileQueryService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<Profile?> Handle(GetProfileByProfileIdQuery query)
        {
            return await _profileRepository.FindByIdAsync(query.id);
        }

        public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
        {
            return await _profileRepository.FindAllProfiles();
        }
    }
}