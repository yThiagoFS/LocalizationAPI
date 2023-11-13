namespace Localization.Domain.ValueObjects;

public sealed record IBGECode : ValueObject 
{
    const string RegexPattern = "^[0-9]*$";

    public string Code { get; }
    
    public IBGECode(string code)
    {
        IsValid(code);
        
        this.Code = code;
    }

    public static implicit operator string(IBGECode ibgeCode) => ibgeCode.Code;

    public static implicit operator IBGECode(string code) => new(code);

    public override string ToString() => this.Code;

    private void IsValid(string code) 
    {
        ThrowIfNullOrEmpty(code, "IBGE code cannot be null or empty.");

        ThrowIfInvalidRegex(code, RegexPattern, "Invalid IBGE code, type only numbers.");

        When(code.Length != 8, "Invalid IBGE code.");
    }
}