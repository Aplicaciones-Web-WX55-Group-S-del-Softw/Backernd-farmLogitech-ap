using Backend_farmlogitech.Subscriptions.Domain.Model.Aggregates;
using Backend_farmlogitech.Subscriptions.Domain.Model.Commands;

namespace Backend_farmlogitech.Subscriptions.Domain.Services;

public interface ISubscriptionCommandService
{
    Task<Subscription> Handle(CreateSubscriptionCommand command); 
    Task<Subscription> Handle(UpdateSubscriptionCommand command);
}