using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Incomes;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.DashboardAnalytics.Infrastructure.Persistence.EFC.Repositories;

public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
{
    public IncomeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Income?>> GetAllByFarmId(int farmid)
    {
        return await Context.Set<Income>()
            .Where(i => i.FarmId == farmid)
            .ToListAsync();
    }

    public Task<Income?> GetByCategoryAndDate(string category, string date)
    {
        return Context.Set<Income>()
            .Where(i => i.Category == category && i.Date == date)
            .FirstOrDefaultAsync();
    }

    public Task<Income?> GetIncomeById(int id)
    {
        return Context.Set<Income>().FirstOrDefaultAsync(f => Equals(f.Id, id));
    }
}