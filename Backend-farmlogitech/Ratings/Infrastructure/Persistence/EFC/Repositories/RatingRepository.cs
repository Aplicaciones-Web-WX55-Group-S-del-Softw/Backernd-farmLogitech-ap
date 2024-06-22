using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Ratings.Domain.Model.Aggregates;
using Backend_farmlogitech.Ratings.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.Ratings.Infrastructure.Persistence.EFC.Repositories;

public class RatingRepository : BaseRepository<Rating>, IRatingRepository
{
    public RatingRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Rating>> FindByAllRatingAsync()
    {
        return await Context.Set<Rating>().ToListAsync();
    }
    
    public async Task<Rating> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Rating>().FirstOrDefaultAsync(r => r.UserId == userId);
    }

    public async  Task<Rating> FindByIdx(int id)
    {
        
        return await Context.Set<Rating>().FirstOrDefaultAsync(f => f.Id == id);
    }
}