using Backend_farmlogitech.Ratings.Domain.Model.Aggregates;
using Backend_farmlogitech.Ratings.Domain.Model.Queries;
using Backend_farmlogitech.Ratings.Domain.Repositories;
using Backend_farmlogitech.Ratings.Domain.Services;

namespace Backend_farmlogitech.Ratings.Application.Internal.QueryServices;

public class RatingQueryService (IRatingRepository ratingRepository) : IRatingQueryService
{
    public async Task<Rating> Handle(GetRatingByIdQuery query)
    {
        return await ratingRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<IEnumerable<Rating>> Handle(GetRatingByUserIdQuery query)
    {
        return await ratingRepository.FindByUserIdAsync(query.UserId);
    }

    public async Task<IEnumerable<Rating>> Handle(GetAllRatingQuery query)
    {
        return await ratingRepository.FindByAllRatingAsync();
    }
}