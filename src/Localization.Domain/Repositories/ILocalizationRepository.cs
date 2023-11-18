using System.Linq.Expressions;

namespace Localization.Domain.Repositories;

public interface ILocalizationRepository : IRepository<Domain.Entities.Localization>
{
    Task<IEnumerable<Localization.Domain.Entities.Localization>>? GetAndFilterBy(List<Expression<Func<Domain.Entities.Localization, bool>>> expressions);

    Task<IEnumerable<Localization.Domain.Entities.Localization>>? GetByCity(string city);

    Task<Localization.Domain.Entities.Localization>? GetByIBGECode(string code);

    Task<IEnumerable<Localization.Domain.Entities.Localization>>? GetByState(string state);

    Task<IEnumerable<Localization.Domain.Entities.Localization>>? GetByZipCode(string code);
}