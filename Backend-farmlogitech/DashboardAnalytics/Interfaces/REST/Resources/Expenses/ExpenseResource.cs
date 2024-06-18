namespace Backend_farmlogitech.DashboardAnalytics.Interfaces.Resources.Expenses;

public record ExpenseResource(int Id, string Category, string Period, string Description, double Amount, string Date);