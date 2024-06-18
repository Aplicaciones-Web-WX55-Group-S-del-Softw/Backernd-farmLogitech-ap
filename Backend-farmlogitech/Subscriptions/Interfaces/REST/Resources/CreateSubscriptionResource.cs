namespace Backend_farmlogitech.Subscriptions.Interfaces.REST.Resources;

public record CreateSubscriptionResource( int Price, string Description, bool Paid, int ProfileId);