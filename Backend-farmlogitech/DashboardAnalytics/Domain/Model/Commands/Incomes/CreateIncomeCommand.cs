namespace Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Incomes;

public record CreateIncomeCommand(string Category, string Period, string Description, double Amount, string Date);