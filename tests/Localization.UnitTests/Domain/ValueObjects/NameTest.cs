using FluentAssertions;
using Localization.Domain.Common.Exceptions;
using Localization.Domain.ValueObjects;
using Localization.UnitTests.Utils;

namespace Localization.UnitTests.Domain.ValueObjects 
{
    public class NameTest : BaseValueObjectTest
    {
        [Theory]
        [InlineData("Thiago")]
        [InlineData("Lucas")]
        [InlineData("José")]
        [InlineData("Ana")]
        public void ShouldCreateAValidName(string userName) 
        {
            var name = new Name(userName);

            name.Value.Should().BeSameAs(userName);
        }
        
        [Fact]
        public void ShouldThrowAValidationExceptionWithNameNullOrEmptyMessage() 
        {
            var message = "Name cannot be null or empty.";

            Name Action() => new(string.Empty);

            ValidateExceptionError<Name>(Action, message);
        }

        [Fact]
        public void ShouldThrowAValidationExceptionWithNameTooLargeMessage() 
        {
            int quantityOfLetters = 100;

            var message = "Name is too large. Maximum 60 characters.";

            Name Action() => new(GenerateRandomText.Generate(quantityOfLetters));

            ValidateExceptionError<Name>(Action, message);
        }

        [Theory]
        [InlineData("ab")]
        [InlineData("ze")]
        [InlineData("bc")]
        [InlineData("ca")]
        public void ShouldThrowAValidationExceptionWithNameTooShortMessage(string name) 
        {
            var message = "Name is too short. Minimum 3 characters.";

            Name Action() => new(name);

            ValidateExceptionError<Name>(Action, message);
        }
    }
}