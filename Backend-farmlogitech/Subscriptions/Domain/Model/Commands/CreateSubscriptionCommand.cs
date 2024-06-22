namespace Backend_farmlogitech.Subscriptions.Domain.Model.Commands;

public record CreateSubscriptionCommand(int Price, string Description, bool Paid, int ProfileId);