using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;

namespace Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Incomes;

public interface IIncomeRepository : IBaseRepository<Income>
{
    Task<IEnumerable<Income?>> GetAllByFarmId(int Farmid); 
    Task<Income?> GetByCategoryAndDate(string category, string date); 
    
    Task<Income?> GetIncomeById(int id);
}