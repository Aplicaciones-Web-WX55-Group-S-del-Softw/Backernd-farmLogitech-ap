using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Ratings.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Ratings.Domain.Repositories;

public interface IRatingRepository: IBaseRepository<Rating>
{
    Task<Rating>FindByUserIdAsync(int userId);
 
    Task<IEnumerable<Rating>> FindByAllRatingAsync();
   
    
    Task<Rating> FindByIdx(int id);
}