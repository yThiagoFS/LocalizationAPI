using System.Linq.Expressions;

namespace Localization.Domain.Repositories;

public interface ILocalizationRepository 
{
    Task<IEnumerable<Localization.Domain.Entities.Localization>>? GetAndFilterBy(List<Expression<Func<Domain.Entities.Localization, bool>>> expressions);
}