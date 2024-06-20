using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Commands;
using Backend_farmlogitech.Profiles.Domain.Repositories;
using Backend_farmlogitech.Profiles.Domain.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;

namespace Backend_farmlogitech.Profiles.Application.Internal.CommandServices
{
    public class ProfileCommandService : IProfileCommandService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _dbContext; // Use AppDbContext here
        private readonly IUserRepository userRepository;

        public ProfileCommandService(IProfileRepository profileRepository, IHttpContextAccessor httpContextAccessor, AppDbContext dbContext, IUserRepository userRepository) // Use AppDbContext here
        {
            _profileRepository = profileRepository;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            this.userRepository = userRepository;
        }

        public async Task<Profile> Handle(CreateProfileCommand command)
        {
            var userId = User.UserAuthenticate.UserId;

            // Get the role of the user
            var userRole = await userRepository.GetUserRole(userId);

            // Check if the user role is allowed to create a profile
            if (userRole.Role != Role.FARMER && userRole.Role != Role.OWNER)
            {
                throw new Exception("Only users with allowed role can create a profile");
            }

            // Check if the user has already created a profile
            var existingProfile = await _profileRepository.GetProfileByUserId(userId);
            if (existingProfile != null)
            {
                throw new Exception("User has already created a profile");
            }

            var profile = new Profile(command)
            {
                id = userId
            };

            profile.userId = userId;
            await _profileRepository.AddAsync(profile);
            await _dbContext.SaveChangesAsync(); // Add this line

            return profile;
        }
    }
}