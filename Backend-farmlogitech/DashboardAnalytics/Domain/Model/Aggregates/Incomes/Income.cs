using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Incomes;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;

public class Income
{
    public int Id { get; private set;  }
    
    public string Category { get; private set; }
    
    public string Description { get; private set; }
    
    public double Amount { get; private set; }
    
    public string Date { get; private set; }
    
    public string Period { get; private set; }
    
    protected Income()
    {
        Category = string.Empty;
        Description = string.Empty;
        Amount = 0;
        Date = string.Empty;
        Period = string.Empty;
    }
    
    public Income(CreateIncomeCommand command)
    {
        this.Description=command.Description;
        this.Category=command.Category;
        this.Amount=command.Amount;
        this.Date=command.Date;
        this.Period=command.Period;
    }
    
}