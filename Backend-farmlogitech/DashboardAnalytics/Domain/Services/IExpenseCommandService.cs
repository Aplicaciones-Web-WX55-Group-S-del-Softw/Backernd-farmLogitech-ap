using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Expenses;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Services;

public interface IExpenseCommandService
{
    Task<Expense> Handle(CreateExpenseCommand command);
}