namespace backend_famLogitech_aw.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}