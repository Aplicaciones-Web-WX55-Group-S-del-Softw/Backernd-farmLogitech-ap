using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Incomes;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Services;

public interface IIncomeCommandService
{
    Task<Income> Handle(CreateIncomeCommand command);
}