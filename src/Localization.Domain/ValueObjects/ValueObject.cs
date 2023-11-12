using System.Text.RegularExpressions;

namespace Localization.Domain.ValueObjects;

public abstract record ValueObject 
{
    protected static void ThrowIfNullOrEmpty(string value, string message)
    {
        if(string.IsNullOrEmpty(value)) throw new Exception(message);
    }

    protected static void ThrowIfInvalidRegex(string value, string pattern, string message)
    {
        if(!Regex.IsMatch(value, pattern)) throw new Exception(message);
    }
}