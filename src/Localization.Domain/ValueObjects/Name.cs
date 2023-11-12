namespace Localization.Domain.ValueObjects;

public record Name : ValueObject 
{
    public string Value { get; }

    public Name(string value)
    {
        IsValid(value);

        this.Value = value;
    }

    public static implicit operator string(Name name) => name.Value;

    public static implicit operator Name(string value) => new(value);

    private void IsValid(string value) 
    {
        ThrowIfNullOrEmpty(value, "Name cannot be null or empty.");

        if(value.Length < 3) throw new Exception("Name is too short. Minimum 3 characters.");

        if(value.Length > 60) throw new Exception("Name is too large. Maximum 60 characters.");
    }
}