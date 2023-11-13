using FluentAssertions;
using Localization.UnitTests.Builders;

namespace Localization.UnitTests.Domain.Entities;

public class UserTest : BaseTest
{
    [Fact]
    public void ShouldCreateAValidUser() 
    {
        const string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        var user = UserBuilder.Build();

        user.Id.Should().NotBeEmpty();
        user.Name.Value.Should().NotBeNullOrEmpty();
        user.Email.Address.Should().NotBeNullOrEmpty().And.MatchRegex(emailPattern);
        user.Password.Value.Should().NotBeNullOrEmpty();
        user.CreatedAt.ToString(DateTimeFormatToComparison).Should()
            .BeEquivalentTo(DateTime.UtcNow.ToString(DateTimeFormatToComparison));
    }
}