using Localization.Domain.Common.Exceptions;

namespace Localization.Domain.ValueObjects;

public record Password : ValueObject 
{
    public string Value { get; private set; }

    public Password(string value)
    {
        IsValid(value);

        this.Value = value;
    }

    public static implicit operator string(Password password) => password.Value;

    public static implicit operator Password(string value) => new(value);

    private void IsValid(string value)
    {
        ThrowIfNullOrEmpty(value, "Password cannot be null or empty.");

        When(value.Length < 6, "Password too small. Minimum 6 characters");

        When(value.Length > 20, "Password too large. Maximum 20 characters");
    }
}
