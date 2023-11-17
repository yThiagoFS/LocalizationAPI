using Localization.Domain.Entities;
using Localization.Domain.Repositories;
using Localization.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Localization.Infra.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) {}

    public async Task<User?> GetUserWithRoles(Guid id)
        => await this._dbSet
            .AsNoTracking()
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.Id == id);
}