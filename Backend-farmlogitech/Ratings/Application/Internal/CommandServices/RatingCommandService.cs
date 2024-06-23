using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Ratings.Domain.Model.Aggregates;
using Backend_farmlogitech.Ratings.Domain.Model.Commands;
using Backend_farmlogitech.Ratings.Domain.Repositories;
using Backend_farmlogitech.Ratings.Domain.Services;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;

namespace Backend_farmlogitech.Ratings.Application.Internal.CommandServices;

public class RatingCommandService : IRatingCommandService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IRatingRepository ratingRepository;
    private readonly IUserRepository userRepository;

    public RatingCommandService(IUnitOfWork unitOfWork, IRatingRepository ratingRepository, IUserRepository userRepository)
    {
        this.unitOfWork = unitOfWork;
        this.ratingRepository = ratingRepository;
        this.userRepository = userRepository;
    }

    public async Task<Rating> Handle(CreateRatingCommand command)
    {
        var userGlobal = User.UserAuthenticate.UserId;
        if(userGlobal==null||userGlobal==0)
        {
            throw new Exception("User not found");
        }
        var userRole = await userRepository.GetUserRole(userGlobal);
        if (userRole.Role != Role.OWNER || userRole.Role == null)
        {
            throw new Exception("Only users with role OWNER can create a rating");
        }
        
        

        // Check if the rating already exists
        
        var newRating = new Rating(command)
        {
            UserId = userGlobal
        };
        await ratingRepository.AddAsync(newRating);
        await unitOfWork.CompleteAsync();
        return newRating;
    } 
    public async Task<Rating> Handle(UpdateRatingCommand command)
    {
        var userGlobal = User.UserAuthenticate.UserId; 
        var ratingToUpdate = await ratingRepository.FindByIdx(command.Id);
        if (ratingToUpdate == null)
            throw new Exception("Rating with ID does not exist");
        ratingToUpdate.Update(command);
        await unitOfWork.CompleteAsync();
        return ratingToUpdate;
    }
}