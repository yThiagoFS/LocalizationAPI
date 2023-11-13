using Bogus;

namespace Localization.UnitTests.Builders;

public class LocalizationBuilder : Faker<Localization.Domain.Entities.Localization>
{
    public static Localization.Domain.Entities.Localization Build()
        => new Faker<Localization.Domain.Entities.Localization>()
        .CustomInstantiator(f => Localization.Domain.Entities.Localization.Create(
            f.Random.Number(10000000).ToString()[0..8],
            f.Address.StateAbbr(),
            f.Random.Number(10000000).ToString()[0..8],
            f.Name.FullName()
        ));
}