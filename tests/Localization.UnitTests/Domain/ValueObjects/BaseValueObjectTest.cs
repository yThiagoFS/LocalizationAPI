using FluentAssertions;
using Localization.Domain.Common.Exceptions;

namespace Localization.UnitTests.Domain.ValueObjects 
{
    public abstract class BaseValueObjectTest 
    {
        public void ValidateExceptionError<T>(Func<T> action, string message) 
        {
            FluentActions
                .Invoking(action)
                .Should()
                .Throw<ValidationException>()
                .WithMessage(message);
        }
    }
}