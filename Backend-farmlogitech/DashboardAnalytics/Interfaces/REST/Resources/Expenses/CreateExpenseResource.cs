namespace Backend_farmlogitech.DashboardAnalytics.Interfaces.Resources.Expenses;

public record CreateExpenseResource(string Category, string Period, string Description, double Amount, string Date);