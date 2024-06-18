using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Incomes;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.DashboardAnalytics.Infrastructure.Persistence.EFC.Repositories;

public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
{
    public IncomeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Income>> GetAllByCategoryAndPeriod(string category, string period)
    {
        return await Context.Set<Income>()
            .Where(i => i.Category == category && i.Period == period)
            .ToListAsync();
    }

    public Task<Income?> GetByCategoryAndPeriod(string category, string period)
    {
        return Context.Set<Income>()
            .Where(i => i.Category == category && i.Period == period)
            .FirstOrDefaultAsync();
    }
}