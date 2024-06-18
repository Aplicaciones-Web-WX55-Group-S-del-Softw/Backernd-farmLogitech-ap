using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Tasks;
using AggregatesTask = Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.Monitoring.Infrastructure.Persistence.EFC.Repositories.Tasks;

public class TaskRepository : BaseRepository<AggregatesTask>, ITaskRepository
{
    public TaskRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<AggregatesTask>> FindByCollaboratorIdAsync(int collaboratorId)
    {
        return await Context.Set<AggregatesTask>().Where(t => t.CollaboratorId == collaboratorId).ToListAsync();
    }

    public async Task<IEnumerable<AggregatesTask>> FindByCollaboratorIdAndFarmerIdAsync(int collaboratorId, int farmerId)
    {
        return await Context.Set<AggregatesTask>().Where(t => t.CollaboratorId == collaboratorId && t.FarmerId == farmerId).ToListAsync();
    }

    public async Task<AggregatesTask> FindByIdx(int id)
    {
        return await Context.Set<AggregatesTask>().FirstOrDefaultAsync(t => t.Id == id);
    }
}