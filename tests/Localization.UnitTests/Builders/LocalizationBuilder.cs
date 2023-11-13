using Bogus;

namespace Localization.UnitTests.Builders;

public class LocalizationBuilder : Faker<Localization.Domain.Entities.Localization>
{
    const int minCodeValue = 10000000;
    const int maxCodeValue = 99999999;

    public static Localization.Domain.Entities.Localization Build(
            string? ibgeCode = null
            , string? state = null
            , string? zipCode = null
            , string? userFullName = null)
        => new Faker<Localization.Domain.Entities.Localization>()
        .CustomInstantiator(f => Localization.Domain.Entities.Localization.Create(
            ibgeCode ?? GetRandomCode(minCodeValue, maxCodeValue),
            state ?? f.Address.StateAbbr(),
            zipCode ?? GetRandomCode(minCodeValue, maxCodeValue),
            userFullName ?? f.Name.FullName()
        ));

     private static string GetRandomCode(int minLength = int.MinValue, int maxLength = int.MaxValue)
        => new Faker().Random.Number(minLength, maxLength).ToString()[0..8];
}