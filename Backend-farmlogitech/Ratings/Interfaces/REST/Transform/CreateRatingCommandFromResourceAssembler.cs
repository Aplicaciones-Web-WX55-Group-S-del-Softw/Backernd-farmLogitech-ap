using Backend_farmlogitech.Ratings.Domain.Model.Commands;
using Backend_farmlogitech.Ratings.Interfaces.REST.Resources;

namespace Backend_famLogitech.Ratings.Interfaces.REST.Transform;

public static class CreateRatingCommandFromResourceAssembler
{
    public static CreateRatingCommand ToCommandFromResource(CreateRatingResource resource)
    {
        return new CreateRatingCommand(resource.Id, resource.StarRating, resource.UserId);
    }
}