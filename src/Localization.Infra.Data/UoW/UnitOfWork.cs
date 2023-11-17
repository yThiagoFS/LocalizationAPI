using Localization.Domain.UoW;
using Localization.Infra.Data.Context;

namespace Localization.Infra.Data.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private bool _disposed = false;

    public UnitOfWork(AppDbContext context) 
        => this._context = context;  

    public async Task BeginTransaction()
        => await this._context.Database.BeginTransactionAsync();

    public async Task Commit()
        => await this._context.SaveChangesAsync();

    public async Task Dispose()
        => await Dispose(true);

    public async Task RollbackTransaction()
        => await this._context.Database.RollbackTransactionAsync();
    
    protected async Task Dispose(bool disposing)
    {
        if(!this._disposed && disposing)
            await this._context.DisposeAsync();

        this._disposed = true;
    }
}
