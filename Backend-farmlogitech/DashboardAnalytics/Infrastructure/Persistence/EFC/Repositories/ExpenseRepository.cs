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
    public async Task<IEnumerable<Expense>> GetAllByCategoryAndPeriod(string category, string period)
    {
        return await Context.Set<Expense>()
            .Where(i => i.Category == category && i.Period == period)
            .ToListAsync();
    }

    public async Task<Expense?> GetByCategoryAndPeriod(string category, string period)
    {
        return await Context.Set<Expense>()
            .Where(i => i.Category == category && i.Period == period)
            .FirstOrDefaultAsync();
    }
}