using Localization.Domain.Entities;
using Localization.Domain.Repositories;
using Localization.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Localization.Infra.Data.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly AppDbContext _context;

    protected readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
         this._context = context;
         this._dbSet = this._context.Set<T>();
    } 

    public virtual async Task Add(T entity)
        => await this._dbSet.AddAsync(entity);

    public virtual async Task<IEnumerable<T>> GetAll()
        => await this._dbSet.AsNoTracking().ToListAsync();

    public virtual async Task<T?> GetById(Guid id)
        => await this._dbSet.SingleOrDefaultAsync(x => x.Id == id);

    public virtual async Task Remove(T entity)
        => await Task.Run(() => this._dbSet.Remove(entity));
        
    public async Task Update(T entity)
        => await Task.Run(() => this._dbSet.Update(entity));
}