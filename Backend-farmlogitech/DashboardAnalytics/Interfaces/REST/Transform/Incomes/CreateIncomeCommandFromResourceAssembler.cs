using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Interfaces.Resources.Incomes;

namespace Backend_farmlogitech.DashboardAnalytics.Interfaces.Transform.Incomes;

public class CreateIncomeCommandFromResourceAssembler
{
    public static CreateIncomeCommand ToCommandFromResource(CreateIncomeResource resource)
    {
        return new CreateIncomeCommand(resource.Category, resource.Period, resource.Description, 
            resource.Amount, resource.Date, resource.FarmId);
    }
}