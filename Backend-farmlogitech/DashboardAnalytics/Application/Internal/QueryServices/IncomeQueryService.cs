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
        return await _incomeRepository.GetIncomeById(query.id);
    }

    public async Task<Income?> Handle(GetIncomeByCategoryAndDateQuery query)
    {
        return await _incomeRepository.GetByCategoryAndDate(query.Category, query.Date);
    }

    public async Task<IEnumerable<Income>> Handle(GetAllIncomeByFarmIdQuery query)
    {
        return await _incomeRepository.GetAllByFarmId(query.Farmid);
    }
}