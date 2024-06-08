namespace Backend_farmlogitech.Subscriptions.Interfaces.REST.Resources;

public record CreateSubscriptionResource(int Id, int Price, string Description, bool Paid, int ProfileId);