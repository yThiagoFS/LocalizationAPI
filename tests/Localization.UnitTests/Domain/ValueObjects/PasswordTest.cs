using FluentAssertions;
using Localization.Domain.ValueObjects;
using Localization.UnitTests.Utils;

namespace Localization.UnitTests.Domain.ValueObjects;

public class PasswordTest : BaseTest
{
    [Fact]
    public void ShouldCreateAValidPassword() 
    {
        const int minPasswordLength = 6;

        const int maxPasswordLength = 20;

        var random = new Random();

        var passwordGenerated = GenerateRandomText.Generate(random.Next(minPasswordLength, maxPasswordLength));

        var password = new Password(passwordGenerated);

        password.Value.Should().BeSameAs(passwordGenerated);
    }

    [Fact]
    public void ShouldThrowAValidationExceptionWithPasswordNullOrEmptyMessage() 
    {
        var message = "Password cannot be null or empty.";

        Password Action() => new(string.Empty);

        ValidateExceptionError<Password>(Action, message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void ShouldThrowAValidationExceptionWithPasswordTooSmallMessage(int passwordLength) 
    {
        var message = "Password too small. Minimum 6 characters";

        Password Action() => new(GenerateRandomText.Generate(passwordLength));

        ValidateExceptionError<Password>(Action, message);
    }

    [Theory]
    [InlineData(21)]
    [InlineData(30)]
    [InlineData(40)]
    [InlineData(65)]
    [InlineData(75)]
    public void ShouldThrowAValidationExceptionWithPasswordTooLargeMessage(int passwordLength) 
    {
        var message = "Password too large. Maximum 20 characters";

        Password Action() => new(GenerateRandomText.Generate(passwordLength));

        ValidateExceptionError<Password>(Action, message);
    }
}