using backend_famLogitech_aw.Shared.Domain.Repositories;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}