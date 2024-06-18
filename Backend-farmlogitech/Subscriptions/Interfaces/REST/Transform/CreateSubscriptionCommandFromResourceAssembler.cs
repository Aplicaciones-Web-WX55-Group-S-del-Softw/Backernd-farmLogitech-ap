using Backend_farmlogitech.Subscriptions.Domain.Model.Commands;
using Backend_farmlogitech.Subscriptions.Interfaces.REST.Resources;

namespace Backend_farmlogitech.Subscriptions.Interfaces.REST.Transform;

public class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource resource)
    {
        return new CreateSubscriptionCommand(resource.Id, resource.Price, resource.Description, resource.Paid,
            resource.ProfileId);
    }
}