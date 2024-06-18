using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Queries.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;

namespace Backend_farmlogitech.DashboardAnalytics.Application.Internal.QueryServices;

public class ExpenseQueryService : IExpenseQueryService
{
    private readonly IExpenseRepository _ExpenseRepository;

    public ExpenseQueryService(IExpenseRepository ExpenseRepository)
    {
        _ExpenseRepository = ExpenseRepository;
    }

    public async Task<Expense> Handle(GetExpenseByIdQuery query)
    {
        return await _ExpenseRepository.FindByIdAsync(query.Id);
    }

    public async Task<Expense?> Handle(GetExpenseByCategoryAndPeriodQuery query)
    {
        return await _ExpenseRepository.GetByCategoryAndPeriod(query.Category, query.Period);
    }

    public async Task<IEnumerable<Expense>> Handle(GetAllByCategoryAndPeriodQuery query)
    {
        return await _ExpenseRepository.GetAllByCategoryAndPeriod(query.Category, query.Period);
    }
}