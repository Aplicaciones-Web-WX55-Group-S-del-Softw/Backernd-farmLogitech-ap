using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Expenses;

public interface IExpenseRepository : IBaseRepository<Expense>
{
    Task<IEnumerable<Expense>> GetAllByFarmId(int FarmId); 
    Task<Expense?> GetByCategoryAndDate(string category, string date); 
    
    Task<Expense?> GetExpenseById(int id);

}