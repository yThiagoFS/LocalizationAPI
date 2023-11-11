using System.Text.RegularExpressions;

namespace Localization.Domain.ValueObjects;

public abstract record ValueObject 
{
    protected bool ValidateRegex(string value, string pattern) 
        => Regex.IsMatch(value, pattern);
}