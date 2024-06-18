using Backend_farmlogitech.Subscriptions.Domain.Model.Commands;
using Backend_farmlogitech.Subscriptions.Interfaces.REST.Resources;

namespace Backend_farmlogitech.Subscriptions.Interfaces.REST.Transform;

public class UpdateSubscriptionCommandFromResourceAssembler
{
    public static UpdateSubscriptionCommand ToCommandFromResource(UpdateSubscriptionResource resource)
    {
        return new UpdateSubscriptionCommand(resource.Id, resource.Price, resource.Description, 
            resource.Paid,
            resource.ProfileId);
    }
}