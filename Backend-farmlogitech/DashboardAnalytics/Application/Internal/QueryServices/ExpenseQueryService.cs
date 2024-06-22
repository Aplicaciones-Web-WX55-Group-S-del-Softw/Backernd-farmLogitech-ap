using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Queries.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;

namespace Backend_farmlogitech.DashboardAnalytics.Application.Internal.QueryServices;

public class ExpenseQueryService : IExpenseQueryService
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseQueryService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public async Task<Expense> Handle(GetExpenseByIdQuery query)
    {
        return await _expenseRepository.GetExpenseById(query.Id);
    }

    public async Task<Expense?> Handle(GetExpenseByCategoryAndDateQuery query)
    {
        return await _expenseRepository.GetByCategoryAndDate(query.Category, query.Date);
    }

    public async Task<IEnumerable<Expense>> Handle(GetAllByFarmIdQuery query)
    {
        return await _expenseRepository.GetAllByFarmId(query.Farmid);
    }
}