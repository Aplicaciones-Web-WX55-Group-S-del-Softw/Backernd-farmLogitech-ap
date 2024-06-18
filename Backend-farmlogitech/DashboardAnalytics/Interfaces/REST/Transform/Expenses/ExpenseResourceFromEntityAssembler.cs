using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Interfaces.Resources.Expenses;

namespace Backend_farmlogitech.DashboardAnalytics.Interfaces.Transform.Expenses;

public static class ExpenseResourceFromEntityAssembler
{
    public static ExpenseResource ToResourceFromEntity(Expense expense)
    {
        return new ExpenseResource(expense.Id, expense.Category, expense.Period, expense.Description, expense.Amount, expense.Date);
    }
}