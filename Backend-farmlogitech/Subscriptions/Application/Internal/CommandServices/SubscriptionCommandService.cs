using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Subscriptions.Domain.Model.Aggregates;
using Backend_farmlogitech.Subscriptions.Domain.Model.Commands;
using Backend_farmlogitech.Subscriptions.Domain.Repositories;
using Backend_farmlogitech.Subscriptions.Domain.Services;

namespace Backend_farmlogitech.Subscriptions.Application.Internal.CommandServices;

public class SubscriptionCommandService : ISubscriptionCommandService
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SubscriptionCommandService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
    {
        _subscriptionRepository = subscriptionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Subscription> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new Subscription(command); 
        await _subscriptionRepository.AddAsync(subscription);
        await _unitOfWork.CompleteAsync(); 
        return subscription;
    }

    public async Task<Subscription> Handle(UpdateSubscriptionCommand command)
    {
        var sub = await _subscriptionRepository.FindByIdAsync(command.Id);
        if (sub == null)
        {
            throw new Exception("Subscription with ID does not exist");
        }
        sub.Update(command);
        await _unitOfWork.CompleteAsync();
        return sub;
    }
}