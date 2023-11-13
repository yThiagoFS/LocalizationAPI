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
        ThrowIfNullOrEmpty(code, "Zip code cannot be null or empty.");

        ThrowIfInvalidRegex(code, RegexPattern, "Invalid zip code, type only numbers.");

        When(code.Length != 8, "Invalid zip code.");
    }
}