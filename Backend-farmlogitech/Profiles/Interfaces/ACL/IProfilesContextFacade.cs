using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Profiles.Interfaces.ACL
{
    public interface IProfilesContextFacade
    {
        Task<int> CreateProfile(string name, string email, string direction, string documentNumber, string documentType, int userId);
        Task<Profile?> FetchProfileById(int id);
    }
}