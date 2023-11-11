namespace Localization.Domain.ValueObjects;

public sealed record ZipCode : ValueObject 
{
    const string RegexPattern = "^[0-9]*$";

    public string Code { get; }

    public ZipCode(string code) 
    {
        IsValid(code);

        this.Code = code;
    }

    public static implicit operator string(ZipCode zipCode) => zipCode.Code;

    public static implicit operator ZipCode(string zipCode) => new(zipCode);

    private void IsValid(string code) 
    {
        if(string.IsNullOrEmpty(code)) throw new Exception("Code cannot be null or empty.");

        if(!ValidateRegex(code, RegexPattern)) throw new Exception("Invalid regex, type only numbers.");

        if(code.Length != 8) throw new Exception("Invalid zip code.");
    }
}