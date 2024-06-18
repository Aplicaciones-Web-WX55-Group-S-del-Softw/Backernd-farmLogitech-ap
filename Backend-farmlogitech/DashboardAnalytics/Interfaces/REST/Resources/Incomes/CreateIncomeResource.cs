namespace Backend_farmlogitech.DashboardAnalytics.Interfaces.Resources.Incomes; 

public record CreateIncomeResource(string Category, string Period, string Description, double Amount, string Date, int FarmId);