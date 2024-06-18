using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Queries;

namespace Backend_farmlogitech.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<Profile> Handle(GetProfileByProfileIdQuery query);
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
}