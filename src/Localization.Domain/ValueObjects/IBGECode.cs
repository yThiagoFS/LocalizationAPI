namespace Localization.Domain.ValueObjects;

public sealed record IBGECode : ValueObject 
{
    public string Code { get; }
    
    public IBGECode(string code)
    {
        this.Code = code;
    }

    public static implicit operator string(IBGECode ibgeCode) => ibgeCode.Code;

    public static implicit operator IBGECode(string code) => new(code);

    public override string ToString() => this.Code;
}