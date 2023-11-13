using FluentAssertions;
using Localization.Domain.ValueObjects;

namespace Localization.UnitTests.Domain.ValueObjects;

public class ZipCodeTest : BaseValueObjectTest
{
    [Theory]
    [InlineData("01156000")]
    [InlineData("01156900")]
    [InlineData("44091126")]
    public void ShouldCreateAValidZipCode(string code) 
    {
        var zipCode = new ZipCode(code);

        zipCode.Code.Should().BeSameAs(code);
    }

    [Fact]
    public void ShouldThrowAValidationExceptionWithZipCodeNullOrEmptyMessage() 
    {
        var message = "Zip code cannot be null or empty.";

        ZipCode Action() => new(string.Empty);

        ValidateExceptionError<ZipCode>(Action, message);
    }

    [Theory]
    [InlineData("0115600@")]
    [InlineData("-11!6900")]
    [InlineData("abcdefgh")]
    [InlineData("A4091126")]
    public void ShouldThrowAValidationExceptionWithInvalidZipCodeFormatMessage(string code) 
    {
        var message = "Invalid zip code, type only numbers.";

        ZipCode Action() => new(code);

        ValidateExceptionError<ZipCode>(Action, message);
    }

    [Theory]
    [InlineData("0115600")]
    [InlineData("011569002")]
    public void ShouldThrowAValidationExceptionWithInvalidZipCodeMessage(string code) 
    {
        var message = "Invalid zip code.";

        ZipCode Action() => new(code);

        ValidateExceptionError<ZipCode>(Action, message);
    }
}