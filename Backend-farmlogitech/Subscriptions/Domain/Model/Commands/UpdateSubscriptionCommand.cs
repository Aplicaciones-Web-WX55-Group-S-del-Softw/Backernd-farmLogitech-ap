namespace Backend_farmlogitech.Subscriptions.Domain.Model.Commands;

public record UpdateSubscriptionCommand(int Id, int Price, string Description, bool Paid, int ProfileId);