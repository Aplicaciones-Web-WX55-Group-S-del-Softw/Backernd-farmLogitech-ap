using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Subscriptions.Domain.Model.Aggregates;
using Backend_farmlogitech.Subscriptions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.Subscriptions.Infrastructure.Persistance.EFC.Repositories;

public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Subscription?> FindByProfileId(int profileId)
    {
        return await Context.Set<Subscription>().FirstOrDefaultAsync(s => s.ProfileId == profileId);
    }

    public async Task<IEnumerable<Subscription>> FindAll()
    {
        return await Context.Set<Subscription>().ToListAsync();
    }
}