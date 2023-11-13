namespace Localization.Domain.UoW;

public interface IUnitOfWork 
{
    Task Commit();

    Task Dispose();

    Task BeginTransaction();

    Task RollbackTransaction();
}