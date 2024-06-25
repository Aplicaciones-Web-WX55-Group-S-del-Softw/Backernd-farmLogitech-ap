using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.DashboardAnalytics.Infrastructure.Persistence.EFC.Repositories;

public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(AppDbContext context) : base(context)
    {
    }
    
    public Task<Expense?> GetExpenseById(int id)
    {
        return Context.Set<Expense>().FirstOrDefaultAsync(f => Equals(f.Id, id));
    }
    public async Task<IEnumerable<Expense>> GetAllByFarmId(int farmid)
    {
        return await Context.Set<Expense>()
            .Where(i => i.FarmId == farmid)
            .ToListAsync();
    }

    public async Task<Expense?> GetByCategoryAndDate(string category, string date)
    {
        return await Context.Set<Expense>()
            .Where(i => i.Category == category && i.Date == date)
            .FirstOrDefaultAsync();
    }
}