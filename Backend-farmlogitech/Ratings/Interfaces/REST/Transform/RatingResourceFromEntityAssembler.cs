using Backend_farmlogitech.Ratings.Interfaces.REST.Resources;

namespace Backend_farmlogitech.Ratings.Interfaces.REST.Transform;

public static class RatingResourceFromEntityAssembler
{
    public static RatingResource ToResourceFromEntity(Backend_farmlogitech.Ratings.Domain.Model.Aggregates.Rating entity)
    {
        return new RatingResource(entity.Id, entity.StarRating, entity.UserId);
    }
}