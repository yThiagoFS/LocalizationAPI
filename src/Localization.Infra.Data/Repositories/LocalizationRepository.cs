using Localization.Domain.Repositories;
using Localization.Infra.Data.Context;

namespace Localization.Infra.Data.Repositories;

public class LocalizationRepository : Repository<Domain.Entities.Localization>, ILocalizationRepository  
{
    public LocalizationRepository(AppDbContext context) : base(context) {}
}