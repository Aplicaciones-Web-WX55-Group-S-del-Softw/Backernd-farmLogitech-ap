using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Incomes;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;

public class Income
{
    public int Id { get;  set;  }
    
    public string Category { get;  set; }
    
    public string Description { get;  set; }
    
    public double Amount { get;  set; }
    
    public string Date { get;  set; }
    
    public string Period { get;  set; }
    
    public int FarmId{ get;  set; }
    
    protected Income()
    {
        Category = string.Empty;
        Description = string.Empty;
        Amount = 0;
        Date = string.Empty;
        Period = string.Empty;
        FarmId = 0;
    }
    
    public Income(CreateIncomeCommand command)
    {
        this.Description=command.Description;
        this.Category=command.Category;
        this.Amount=command.Amount;
        this.Date=command.Date;
        this.Period=command.Period;
        this.FarmId=command.FarmId;
    }
    
}