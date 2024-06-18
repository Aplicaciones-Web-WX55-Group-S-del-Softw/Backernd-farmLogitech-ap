using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Commands;
using Backend_farmlogitech.Profiles.Domain.Repositories;
using Backend_farmlogitech.Profiles.Domain.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Backend_farmlogitech.Profiles.Application.Internal.CommandServices
{
    public class ProfileCommandService : IProfileCommandService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _dbContext; // Use AppDbContext here

        public ProfileCommandService(IProfileRepository profileRepository, IHttpContextAccessor httpContextAccessor, AppDbContext dbContext) // Use AppDbContext here
        {
            _profileRepository = profileRepository;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext; 
        }

        public async Task<Profile> Handle(CreateProfileCommand command)
        {
            var userIdClaim = command.UserId.ToString(); // Use the UserId from the command directly

            if (!int.TryParse(userIdClaim, out var userId))
            {
                throw new InvalidOperationException("User ID claim is not a valid integer.");
            }

            var profile = new Profile(command)
            {
                id = userId
            };

            await _profileRepository.AddAsync(profile);
            await _dbContext.SaveChangesAsync(); // Add this line

            return profile;
        }
    }
}