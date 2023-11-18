using System.Linq.Expressions;
using Localization.Domain.Repositories;
using Localization.Infra.Data.Context;
using Localization.Domain.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Localization.Infra.Data.Repositories;

public class LocalizationRepository : Repository<Domain.Entities.Localization>, ILocalizationRepository  
{
    public LocalizationRepository(AppDbContext context) : base(context) {}

    public async Task<IEnumerable<Domain.Entities.Localization>>? GetAndFilterBy(List<Expression<Func<Domain.Entities.Localization, bool>>> expressions)
        => await this._dbSet.FilterQuery(expressions).ToListAsync();
}