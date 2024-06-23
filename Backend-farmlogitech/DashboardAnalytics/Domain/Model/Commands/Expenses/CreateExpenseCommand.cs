namespace Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Expenses;

public record CreateExpenseCommand(string Category, string Period, string Description, double Amount, string Date);