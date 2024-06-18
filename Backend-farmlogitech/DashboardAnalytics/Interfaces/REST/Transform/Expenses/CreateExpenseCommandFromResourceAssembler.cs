using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Interfaces.Resources.Expenses;

namespace Backend_farmlogitech.DashboardAnalytics.Interfaces.Transform.Expenses;

public class CreateExpenseCommandFromResourceAssembler
{
    public static CreateExpenseCommand ToCommandFromResource(CreateExpenseResource resource)
    {
        return new CreateExpenseCommand(resource.Category, resource.Period, resource.Description, resource.Amount, resource.Date, resource.FarmId);
    }
}