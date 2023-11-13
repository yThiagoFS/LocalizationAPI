using FluentAssertions;
using Localization.Domain.ValueObjects;

namespace Localization.UnitTests.Domain.ValueObjects;

public class IBGECodeTest : BaseTest
{
    [Theory]
    [InlineData("01156000")]
    [InlineData("01156900")]
    [InlineData("44091126")]
    public void ShouldCreateAValidIBGECode(string code) 
    {
        var ibgeCode = new IBGECode(code);

        ibgeCode.Code.Should().BeSameAs(code);
    }

    [Fact]
    public void ShouldThrowAValidationExceptionWithIBGECodeNullOrEmptyMessage() 
    {
        var message = "IBGE code cannot be null or empty.";

        IBGECode Action() => new(string.Empty);

        ValidateExceptionError<IBGECode>(Action, message);
    }

    [Theory]
    [InlineData("0115600@")]
    [InlineData("-11!6900")]
    [InlineData("abcdefgh")]
    [InlineData("A4091126")]
    public void ShouldThrowAValidationExceptionWithInvalidIBGECodeFormatMessage(string code) 
    {
        var message = "Invalid IBGE code, type only numbers.";

        IBGECode Action() => new(code);

        ValidateExceptionError<IBGECode>(Action, message);
    }

    [Theory]
    [InlineData("0115600")]
    [InlineData("011569002")]
    public void ShouldThrowAValidationExceptionWithInvalidIBGECodeMessage(string code) 
    {
        var message = "Invalid IBGE code.";

        IBGECode Action() => new(code);

        ValidateExceptionError<IBGECode>(Action, message);
    }
}