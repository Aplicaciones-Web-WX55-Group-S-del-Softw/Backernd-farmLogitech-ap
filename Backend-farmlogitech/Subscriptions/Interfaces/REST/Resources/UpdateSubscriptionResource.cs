namespace Backend_farmlogitech.Subscriptions.Interfaces.REST.Resources;

public record UpdateSubscriptionResource(int Id, int Price, string Description, bool Paid, int ProfileId);