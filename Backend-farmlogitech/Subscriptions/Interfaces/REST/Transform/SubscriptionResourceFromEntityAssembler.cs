using Backend_farmlogitech.Subscriptions.Domain.Model.Aggregates;
using Backend_farmlogitech.Subscriptions.Interfaces.REST.Resources;

namespace Backend_farmlogitech.Subscriptions.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResource(Subscription subscription)
    {
        return new SubscriptionResource(subscription.Id, subscription.Price, subscription.Description, subscription.Paid, subscription.ProfileId);
    }
}