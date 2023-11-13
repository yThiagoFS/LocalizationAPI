
using FluentAssertions;
using Localization.UnitTests.Builders;

namespace Localization.UnitTests.Domain.Entities;

public class LocalizationTest : BaseTest 
{
    [Fact]
    public void ShouldCreateAValidLocalization() 
    {
        const int stateLength = 2;
        const int ibgeCodeLength = 8;
        const int stateCodeLength = 8;
        const int nameMinLength = 3;
        const int nameMaxLength = 60;

        Localization.Domain.Entities.Localization localization = LocalizationBuilder.Build();

        localization.Id.Should().NotBeEmpty();
        ValidateStringIsNotNullOrEmptyAndLength(localization.IBGECode.Code, ibgeCodeLength);
        ValidateStringIsNotNullOrEmptyAndLength(localization.State.Acronym, stateLength);
        ValidateStringIsNotNullOrEmptyAndLength(localization.ZipCode.Code, stateCodeLength);
        localization.CreatedAt.ToString(DateTimeFormatToComparison).Should()
            .BeEquivalentTo(DateTime.UtcNow.ToString(DateTimeFormatToComparison));
        localization.AddedBy.Value.Should()
            .NotBeNullOrEmpty()
            .And
            .Subject.Length.Should()
                .BeGreaterThanOrEqualTo(nameMinLength)
                .And.BeLessThanOrEqualTo(nameMaxLength);
    }

    private void ValidateStringIsNotNullOrEmptyAndLength(string value, int length)
        => value.Should()
        .NotBeNullOrEmpty()
        .And
        .HaveLength(length);
}