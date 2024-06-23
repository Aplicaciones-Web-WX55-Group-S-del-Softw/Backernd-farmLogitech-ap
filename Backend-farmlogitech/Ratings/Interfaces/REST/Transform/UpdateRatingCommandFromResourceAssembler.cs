using backend_famLogitech.Ratings.Interfaces.REST.Resources;
using Backend_farmlogitech.Ratings.Domain.Model.Commands;

namespace Backend_farmlogitech.Ratings.Interfaces.REST.Transform;

public static class UpdateRatingCommandFromResourceAssembler
{
    public static UpdateRatingCommand ToCommandFromResource(UpdateRatingResource resource)
    {
        return new UpdateRatingCommand(resource.Id, resource.StarRating);
    }
}