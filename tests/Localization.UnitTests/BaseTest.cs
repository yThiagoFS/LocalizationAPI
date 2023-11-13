using FluentAssertions;
using Localization.Domain.Common.Exceptions;

namespace Localization.UnitTests;

public abstract class BaseTest 
{
    protected const string DateTimeFormatToComparison = "yyyy-MM-dd H"; 

    protected static void ValidateExceptionError<T>(Func<T> action, string message) 
    {
        FluentActions
            .Invoking(action)
            .Should()
            .Throw<ValidationException>()
            .WithMessage(message);
    }
}