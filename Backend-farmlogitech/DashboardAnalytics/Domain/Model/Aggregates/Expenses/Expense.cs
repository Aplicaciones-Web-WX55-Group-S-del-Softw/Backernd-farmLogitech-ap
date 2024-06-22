

using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Expenses;
using Backend_farmlogitech.Farms.Domain.Model.Aggregates;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;

public class Expense
{
    public int Id { get; private set;  }
    
    public string Category { get; private set; }
    
    public string Description { get; private set; }
    
    public double Amount { get; private set; }
    
    public string Date { get; private set; }
    
    public string Period { get; private set; }
    
    public int FarmId{ get; private set; }
    
    protected Expense()
    {
        Category = string.Empty;
        Description = string.Empty;
        Amount = 0;
        Date = string.Empty;
        Period = string.Empty;
        FarmId = 0;
    }
    
    public Expense(string category, string period, string description, double amount, string date, int farmId)
    {
        Category = category;
        Description = description;
        Amount = amount;
        Date = date;
        Period = period;
        FarmId = farmId;
    }
    
    public Expense(CreateExpenseCommand command)
    {
        this.Description=command.Description;
        this.Category=command.Category;
        this.Amount=command.Amount;
        this.Date=command.Date;
        this.Period=command.Period;
        this.FarmId=command.FarmId;
    }
    
}