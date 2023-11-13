namespace Localization.Domain.ValueObjects;

public sealed record Email : ValueObject
{
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    public Email(string address)
    {
        IsValid(address);

        Address = address.Trim().ToLower();
    }

    public string Address { get; private set; }

    public static implicit operator string(Email email) => email.ToString();

    public static implicit operator Email(string address) => new(address);

    public override string ToString() => Address;

    private void IsValid(string address)
    {
        ThrowIfNullOrEmpty(address, "E-mail cannot be null.");

        ThrowIfInvalidRegex(address, Pattern, "Invalid e-mail format.");

        When(address.Length <= 6, "E-mail cannot contain less than five characters.");
    }

}