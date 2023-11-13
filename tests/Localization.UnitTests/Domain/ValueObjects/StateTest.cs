using FluentAssertions;
using Localization.Domain.ValueObjects;

namespace Localization.UnitTests.Domain.ValueObjects;

public class StateTest : BaseValueObjectTest
{
    [Theory]
    [InlineData("SP")]
    [InlineData("MG")]
    [InlineData("PR")]
    public void ShouldCreateAValidState(string acronym) 
    {
        var state = new State(acronym);

        state.Acronym.Should().BeSameAs(acronym);
    }

    [Fact]
    public void ShouldThrowAValidationExceptionWithStateNullOrEmptyMessage() 
    {
        var message = "State cannot be null or empty.";

        State Action() => new(string.Empty);

        ValidateExceptionError<State>(Action, message);
    }

    [Theory]
    [InlineData("spa")]
    [InlineData("s")]
    [InlineData("abc")]
    public void ShouldThrowAValidationExceptionWithInvalidStateMessage(string acronym) 
    {
        var message = "Invalid state, use the acronym of the state.";

        State Action() => new(acronym);

        ValidateExceptionError<State>(Action, message);
    }

    [Theory]
    [InlineData("s!")]
    [InlineData("s@")]
    [InlineData("a-")]
    [InlineData("32")]
    public void ShouldThrowAValidationExceptionWithOnlyLettersAreAvaliableMessage(string acronym) 
    {
        var message = "Only letters are avaliable for the state.";

        State Action() => new(acronym);

        ValidateExceptionError<State>(Action, message);
    }
}