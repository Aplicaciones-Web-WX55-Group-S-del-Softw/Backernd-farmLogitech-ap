using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Expenses;
using Backend_farmlogitech.Farms.Domain.Model.Aggregates;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;

public class Expense
{
    public int Id { get; set; }
    
    private string _category;
    private string _description;
    private double _amount;
    private string _date;
    private string _period;
    private int _farmId;

    public string Category
    {
        get { return _category; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Category cannot be null or empty.");
            }
            _category = value;
        }
    }

    public string Description
    {
        get { return _description; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Description cannot be null or empty.");
            }
            _description = value;
        }
    }

    public double Amount
    {
        get { return _amount; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Amount must be greater than 0.");
            }
            _amount = value;
        }
    }

    public string Date
    {
        get { return _date; }
        set
        {
            if (string.IsNullOrEmpty(value) || !DateTime.TryParse(value, out _))
            {
                throw new Exception("Date must be a valid date string.");
            }
            _date = value;
        }
    }

    public string Period
    {
        get { return _period; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Period cannot be null or empty.");
            }
            _period = value;
        }
    }

    public int FarmId
    {
        get { return _farmId; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("FarmId must be greater than 0.");
            }
            _farmId = value;
        }
    }

    protected Expense()
    {
    }

    public Expense(string category, string period, string description, double amount, string date, int farmId)
    {
        this.Category = category;
        this.Period = period;
        this.Description = description;
        this.Amount = amount;
        this.Date = date;
        this.FarmId = farmId;
    }

    public Expense(CreateExpenseCommand command)
    {
        this.Category = command.Category;
        this.Period = command.Period;
        this.Description = command.Description;
        this.Amount = command.Amount;
        this.Date = command.Date;
        this.FarmId = command.FarmId;
    }
}
