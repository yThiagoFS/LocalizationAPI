using FluentAssertions;
using Localization.Domain.ValueObjects;

namespace Localization.UnitTests.Domain.ValueObjects;

public class EmailTest : BaseTest
{
    [Theory]
    [InlineData("fakeadress@gmail.com")]
    [InlineData("somebusiness_company@company.com")]
    [InlineData("somepersonemail123@outlook.com")]
    public void ShouldCreateAValidEmail(string address) 
    {
        var email = new Email(address);

        email.Address.Should().BeSameAs(address);
    }

    [Fact]
    public void ShouldThrowAValidationExceptionWithEmailNullOrEmptyMessage() 
    {
        var message = "E-mail cannot be null.";

        Email Action() => new(string.Empty);

        ValidateExceptionError<Email>(Action, message);
    }

    [Theory]
    [InlineData("fakeadress@.com")]
    [InlineData("@company.com")]
    [InlineData("somerandomemail.")]
    [InlineData("invalid@@gmail.com")]
    public void ShouldThrowAValidationExceptionWithInvalidEmailFormatMessage(string address) 
    {
        var message = "Invalid e-mail format.";

        Email Action() => new(address);

        ValidateExceptionError<Email>(Action, message);
    }

    [Theory]
    [InlineData("a@b.c")]
    [InlineData("i@gm.c")]
    [InlineData("a@ou.c")]
    public void ShouldThrowAValidationExceptionWithInvalidZipCodeMessage(string address) 
    {
        var message = "E-mail cannot contain less than five characters.";

        Email Action() => new(address);

        ValidateExceptionError<Email>(Action, message);
    }
}