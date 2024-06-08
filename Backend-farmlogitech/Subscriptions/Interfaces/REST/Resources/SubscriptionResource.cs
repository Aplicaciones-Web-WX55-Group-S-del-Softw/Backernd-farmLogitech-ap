namespace Backend_farmlogitech.Subscriptions.Interfaces.REST.Resources;

public record SubscriptionResource(int Id, int Price, string Description, bool Paid, int ProfileId);