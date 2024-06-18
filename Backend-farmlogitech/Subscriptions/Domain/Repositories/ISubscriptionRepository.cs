

using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Subscriptions.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Subscriptions.Domain.Repositories;

public interface ISubscriptionRepository : IBaseRepository<Subscription>
{
    Task<Subscription?> FindByProfileId(int profileId);
    Task<IEnumerable<Subscription>> FindAll(); 

}