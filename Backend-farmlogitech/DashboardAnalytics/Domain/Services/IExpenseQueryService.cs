using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Queries.Expenses;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Services;

public interface IExpenseQueryService
{
    Task<Expense> Handle(GetExpenseByIdQuery query);
    Task<Expense> Handle(GetExpenseByCategoryAndDateQuery query);
    Task<IEnumerable<Expense>> Handle(GetAllByFarmIdQuery query);
}