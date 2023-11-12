namespace Localization.Domain.ValueObjects;

public record class Email : ValueObject
{
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    public Email(string address)
    {
        IsValidEmail(address);

        Address = address.Trim().ToLower();
    }

    public string Address { get; set; }

    public static implicit operator string(Email email) => email.ToString();

    public static implicit operator Email(string address) => new(address);

    public override string ToString() => Address;

    private static void IsValidEmail(string address)
    {
        ThrowIfNullOrEmpty(address, "E-mail cannot be null.");

        if (address.Length < 5) throw new Exception("E-mail cannot contain less than five characters.");

        ThrowIfInvalidRegex(address, Pattern, "Invalid e-mail format.");
    }

}