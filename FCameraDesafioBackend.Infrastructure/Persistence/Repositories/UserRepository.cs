using FCameraDesafioBackend.Domain.Entities;
using FCameraDesafioBackend.Domain.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCameraDesafioBackend.Infrastructure.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DefaultDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await DbSet.FirstOrDefaultAsync(x => string.Equals(x.Email.ToLower(), email.ToLower()),
            cancellationToken);
    }
}