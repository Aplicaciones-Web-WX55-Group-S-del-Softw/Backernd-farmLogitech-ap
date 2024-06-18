using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Queries.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Queries.Incomes;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Services;

public interface IIncomeQueryService
{
    Task<Income> Handle(GetIncomeByIdQuery query);
    Task<Income?> Handle(GetIncomeByCategoryAndPeriodQuery query);
    Task<IEnumerable<Income>> Handle(GetAllIncomeByCategoryAndPeriodQuery query);
}