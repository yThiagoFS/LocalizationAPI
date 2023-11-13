using System.Text.RegularExpressions;
using Localization.Domain.Common.Exceptions;

namespace Localization.Domain.ValueObjects;

public abstract record ValueObject 
{
    protected static void ThrowIfNullOrEmpty(string value, string message)
    {
        if(string.IsNullOrEmpty(value)) throw new ValidationException(message);
    }

    protected static void ThrowIfInvalidRegex(string value, string pattern, string message)
    {
        if(!Regex.IsMatch(value, pattern)) throw new ValidationException(message);
    }

    protected static void When(bool condition, string message)
    {
        if(condition)
            throw new ValidationException(message);
    }
}