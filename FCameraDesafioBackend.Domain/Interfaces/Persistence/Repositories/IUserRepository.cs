using FCameraDesafioBackend.Domain.Entities;

namespace FCameraDesafioBackend.Domain.Interfaces.Persistence.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}