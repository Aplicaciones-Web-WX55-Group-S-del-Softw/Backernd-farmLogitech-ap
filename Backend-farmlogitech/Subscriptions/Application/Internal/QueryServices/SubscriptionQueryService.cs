using Backend_farmlogitech.Subscriptions.Domain.Model.Aggregates;
using Backend_farmlogitech.Subscriptions.Domain.Model.Queries;
using Backend_farmlogitech.Subscriptions.Domain.Repositories;
using Backend_farmlogitech.Subscriptions.Domain.Services;

namespace Backend_farmlogitech.Subscriptions.Application.Internal.QueryServices;

public class SubscriptionQueryService : ISubscriptionQueryService
{
    private ISubscriptionRepository _subscriptionRepository;
    public async Task<Subscription> Handle(GetSubscriptionByIdQuery query)
    {
        return await _subscriptionRepository.FindByIdAsync(query.Id); 
    }

    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query)
    {
        return await _subscriptionRepository.FindAll();
    }

    public async Task<Subscription?> Handle(GetSubscriptionByProfileIdQuery query)
    {
        return await _subscriptionRepository.FindByProfileId(query.ProfileId);
    }
}