using Backend_farmlogitech.Subscriptions.Domain.Model.Commands;
using Backend_farmlogitech.Subscriptions.Domain.Model.Commands;

namespace Backend_farmlogitech.Subscriptions.Domain.Model.Aggregates;

public class Subscription 
{
    public int Id { get; private set; }
    
    public int Price { get; private set; }
    
    public string Description { get; private set; }
    
    public bool Paid { get; private set; }
    
    public int ProfileId { get; private set; }

    protected Subscription()
    {
        this.Description= string.Empty;
        this.Paid = false;
        this.Price = 0; 
        this.Id = 0;
        this.ProfileId = 0; 
    }

    public Subscription(CreateSubscriptionCommand command)
    {
        this.Id= command.Id;
        this.Price = command.Price;
        this.Description = command.Description;
        this.Paid = command.Paid;
        this.ProfileId = command.ProfileId;
    }
    
    public void Update(UpdateSubscriptionCommand command)
    {
        this.Price = command.Price;
        this.Description = command.Description;
        this.Paid = command.Paid;
        this.ProfileId= command.ProfileId;
    }
    
   
}