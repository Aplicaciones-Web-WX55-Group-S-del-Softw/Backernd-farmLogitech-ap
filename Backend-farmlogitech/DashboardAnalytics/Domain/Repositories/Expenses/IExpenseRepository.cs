using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Expenses;

public interface IExpenseRepository : IBaseRepository<Expense>
{
    Task<IEnumerable<Expense>> GetAllByCategoryAndPeriod(string category, string period); 
    Task<Expense?> GetByCategoryAndPeriod(string category, string period); 

}