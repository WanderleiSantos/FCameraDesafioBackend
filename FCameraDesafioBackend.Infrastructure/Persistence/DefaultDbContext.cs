using System.Reflection;
using FCameraDesafioBackend.Domain.Entities;
using FCameraDesafioBackend.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FCameraDesafioBackend.Infrastructure.Persistence;

public class DefaultDbContext : DbContext, IUnitOfWork
{
    public DefaultDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    public async Task<bool> CommitAsync()
    {
        var success = await SaveChangesAsync() > 0;
        return success;
    }

    public Task RollbackAsync()
    {
        return Task.CompletedTask;
    }
}