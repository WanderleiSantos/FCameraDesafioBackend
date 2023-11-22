namespace FCameraDesafioBackend.Domain.Interfaces.Persistence.Repositories;

public interface IRepository<TEntity>
{
    IUnitOfWork UnitOfWork { get; }
}