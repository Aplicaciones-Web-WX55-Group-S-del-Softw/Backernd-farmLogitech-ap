using Backend_farmlogitech.Ratings.Domain.Model.Aggregates;
using Backend_farmlogitech.Ratings.Domain.Model.Queries;

namespace Backend_farmlogitech.Ratings.Domain.Services; 

public interface IRatingQueryService
{
    Task<Rating> Handle(GetRatingByIdQuery query);
    
    Task<Rating> Handle(GetRatingByUserIdQuery query);
    
    Task<IEnumerable<Rating>> Handle(GetAllRatingQuery query);
}