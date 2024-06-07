namespace backend_famLogitech_aw.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity>
{
    Task AddAsync(TEntity entity);
    Task<TEntity> FindByIdAsync(int id);
}