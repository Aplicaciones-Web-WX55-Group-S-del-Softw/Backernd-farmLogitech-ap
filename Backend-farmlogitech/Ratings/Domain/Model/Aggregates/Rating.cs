using Backend_farmlogitech.Ratings.Domain.Model.Commands;

namespace Backend_farmlogitech.Ratings.Domain.Model.Aggregates;

public class Rating
{
    protected Rating(int Id, int StarRating, int UserId )
    {
        this.Id = Id;
        this.StarRating = StarRating;
        this.UserId = UserId;
    }

    private int _starRating;
    private int _id;
    private int _userId;

    public int Id
    {
        get { return _id; }
        private set
        {
            _id = value;
        }
    }

    public int StarRating
    {
        get { return _starRating; }
        set
        {
            if (value < 1 || value > 5)
            {
                throw new Exception("StarRating must be between 1 and 5.");
            }
            _starRating = value;
        }
    }

    public int UserId
    {
        get { return _userId; }
        set
        {
            _userId = value;
        }
    }

    public Rating(CreateRatingCommand command)
    {
        this.Id = command.Id;
        this.StarRating = command.StarRating;
        this.UserId = command.UserId;
    }

    public void Update(UpdateRatingCommand command)
    {
        this.StarRating = command.StarRating;
        this.UserId = command.UserId;
    }
}