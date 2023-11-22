using FCameraDesafioBackend.Domain.Entities;
using FCameraDesafioBackend.Domain.Interfaces.Persistence;
using FCameraDesafioBackend.Domain.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCameraDesafioBackend.Infrastructure.Persistence.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DefaultDbContext _context;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(DefaultDbContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }

    public IUnitOfWork UnitOfWork => _context;
    
    
}