using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Interfaces.Resources.Incomes;

namespace Backend_farmlogitech.DashboardAnalytics.Interfaces.Transform.Incomes;

public class IncomeResourceFromEntityAssembler
{
    public static IncomeResource ToResource(Income entity)
    {
        return new IncomeResource(entity.Id, entity.Category, entity.Period, entity.Description, entity.Amount, entity.Date, entity.FarmId);
    }
}