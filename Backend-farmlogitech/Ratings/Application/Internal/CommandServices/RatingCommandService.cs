using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Ratings.Domain.Model.Aggregates;
using Backend_farmlogitech.Ratings.Domain.Model.Commands;
using Backend_farmlogitech.Ratings.Domain.Repositories;
using Backend_farmlogitech.Ratings.Domain.Services;

namespace Backend_farmlogitech.Ratings.Application.Internal.CommandServices;

public class RatingCommandService (IUnitOfWork unitOfWork, IRatingRepository ratingRepository): IRatingCommandService
{
    public async Task<Rating> Handle(CreateRatingCommand command)
    {
        var ratingNew = await ratingRepository.FindByIdx(command.Id);
        if (ratingNew != null)
            throw new Exception("Rating with ID already exists");
        ratingNew = new Rating(command);
        await ratingRepository.AddAsync(ratingNew);
        await unitOfWork.CompleteAsync();
        return ratingNew;
    }

    public async Task<Rating> Handle(UpdateRatingCommand command)
    {
        var ratingToUpdate = await ratingRepository.FindByIdx(command.Id);
        if (ratingToUpdate == null)
            throw new Exception("Rating with ID does not exist");
        ratingToUpdate.Update(command);
        await unitOfWork.CompleteAsync();
        return ratingToUpdate;
    }
}