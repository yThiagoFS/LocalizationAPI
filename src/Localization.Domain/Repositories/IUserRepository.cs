using Localization.Domain.Entities;

namespace Localization.Domain.Repositories;

public interface IUserRepository : IRepository<User> 
{
    Task<User?> GetUserWithRoles(Guid id);
}