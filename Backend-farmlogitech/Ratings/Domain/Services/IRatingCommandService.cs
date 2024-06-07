using Backend_farmlogitech.Ratings.Domain.Model.Aggregates;
using Backend_farmlogitech.Ratings.Domain.Model.Commands;

namespace Backend_farmlogitech.Ratings.Domain.Services;

public interface IRatingCommandService
{ 
    Task<Rating> Handle(CreateRatingCommand command);
    Task<Rating> Handle(UpdateRatingCommand command);
}
