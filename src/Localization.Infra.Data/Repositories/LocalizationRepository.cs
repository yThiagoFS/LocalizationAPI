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

    public async Task<IEnumerable<Domain.Entities.Localization>>? GetByCity(string city)
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Entities.Localization>? GetByIBGECode(string code)
        => await this._dbSet.SingleOrDefaultAsync(l => l.IBGECode.Code == code);

    public async Task<IEnumerable<Domain.Entities.Localization>>? GetByState(string state)
        => await this._dbSet.Where(l => EF.Functions.Like(l.State.Acronym, state.ToUpper())).ToListAsync();

    public async Task<IEnumerable<Domain.Entities.Localization>>? GetByZipCode(string code)
        => await this._dbSet.Where(l => l.ZipCode.Code == code).ToListAsync();
}