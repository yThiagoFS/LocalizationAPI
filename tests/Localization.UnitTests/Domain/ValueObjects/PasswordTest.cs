using FluentAssertions;
using Localization.Domain.ValueObjects;
using Localization.UnitTests.Utils;

namespace Localization.UnitTests.Domain.ValueObjects;

public class PasswordTest : BaseValueObjectTest
{
    [Fact]
    public void ShouldCreateAValidPassword() 
    {
        var random = new Random();
        
        var minPasswordLength = 6;

        var maxPasswordLength = 20;

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

    // [Theory]
    // [InlineData("fakeadress@.com")]
    // [InlineData("@company.com")]
    // [InlineData("somerandomemail.")]
    // [InlineData("invalid@@gmail.com")]
    // public void ShouldThrowAValidationExceptionWithInvalidEmailFormatMessage(string address) 
    // {
    //     var message = "Invalid e-mail format.";

    //     Email Action() => new(address);

    //     ValidateExceptionError<Email>(Action, message);
    // }

    // [Theory]
    // [InlineData("a@b.c")]
    // [InlineData("i@gm.c")]
    // [InlineData("a@ou.c")]
    // public void ShouldThrowAValidationExceptionWithInvalidZipCodeMessage(string address) 
    // {
    //     var message = "E-mail cannot contain less than five characters.";

    //     Email Action() => new(address);

    //     ValidateExceptionError<Email>(Action, message);
    // }
}