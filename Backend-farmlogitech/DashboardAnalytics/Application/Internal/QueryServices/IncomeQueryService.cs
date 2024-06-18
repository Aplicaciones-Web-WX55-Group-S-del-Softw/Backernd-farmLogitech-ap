using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Queries.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;

namespace Backend_farmlogitech.DashboardAnalytics.Application.Internal.QueryServices;

public class IncomeQueryService : IIncomeQueryService
{
    private readonly IIncomeRepository _incomeRepository;

    public IncomeQueryService(IIncomeRepository incomeRepository)
    {
        _incomeRepository = incomeRepository;
    }

    public async Task<Income> Handle(GetIncomeByIdQuery query)
    {
        return await _incomeRepository.FindByIdAsync(query.id);
    }

    public async Task<Income?> Handle(GetIncomeByCategoryAndPeriodQuery query)
    {
        return await _incomeRepository.GetByCategoryAndPeriod(query.Category, query.Period);
    }

    public async Task<IEnumerable<Income>> Handle(GetAllIncomeByCategoryAndPeriodQuery query)
    {
        return await _incomeRepository.GetAllByCategoryAndPeriod(query.Category, query.Period);
    }
}