using Backend_farmlogitech.Subscriptions.Domain.Model.Aggregates;
using Backend_farmlogitech.Subscriptions.Domain.Model.Queries;

namespace Backend_farmlogitech.Subscriptions.Domain.Services;

public interface ISubscriptionQueryService
{
    Task<Subscription> Handle(GetSubscriptionByIdQuery query);
    Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query);
    Task<Subscription?> Handle(GetSubscriptionByProfileIdQuery query);
}