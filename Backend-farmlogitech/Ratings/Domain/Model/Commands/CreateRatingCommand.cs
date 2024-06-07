namespace Backend_farmlogitech.Ratings.Domain.Model.Commands;

public record CreateRatingCommand(int Id, int StarRating, int UserId);