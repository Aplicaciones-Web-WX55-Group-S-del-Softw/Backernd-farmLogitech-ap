using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.Profiles.Infrastructure.Persistance.EFC.Repositories;

public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Employee>> FindAllEmployee()
    {
        return await Context.Set<Employee>().ToListAsync();
    }

    public async Task<Employee?> FindById(int id)
    {
        return await Context.Set<Employee>().FirstOrDefaultAsync(f => f.Id== id);}

    public async Task<IEnumerable<Employee>> FindEmployeesByFarmId(int farmId)
    {
        return await Context.Set<Employee>().Where(e => e.FarmId == farmId).ToListAsync();
    }
}

  