using Localization.Domain.Common.Exceptions;

namespace Localization.Domain.ValueObjects;

public record class Email : ValueObject
{
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    public Email(string address)
    {
        IsValidEmail(address);

        Address = address.Trim().ToLower();
    }

    public string Address { get; private set; }

    public static implicit operator string(Email email) => email.ToString();

    public static implicit operator Email(string address) => new(address);

    public override string ToString() => Address;

    private void IsValidEmail(string address)
    {
        ThrowIfNullOrEmpty(address, "E-mail cannot be null.");

        ThrowIfInvalidRegex(address, Pattern, "Invalid e-mail format.");

        When(address.Length < 5, "E-mail cannot contain less than five characters.");
    }

}