namespace Localization.Domain.ValueObjects;

public sealed record ZipCode : ValueObject 
{
    const string RegexPattern = "^[0-9]*$";

    public string Code { get; }

    public ZipCode(string code) 
    {
        IsValid(code);

        this.Code = code.Trim();
    }

    public static implicit operator string(ZipCode zipCode) => zipCode.Code;

    public static implicit operator ZipCode(string zipCode) => new(zipCode);

    private void IsValid(string code) 
    {
        ThrowIfNullOrEmpty(code, "Code cannot be null or empty.");

        ThrowIfInvalidRegex(code, RegexPattern, "Invalid regex, type only numbers.");

        if(code.Length != 8) throw new Exception("Invalid zip code.");
    }
}