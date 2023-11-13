using Localization.Domain.ValueObjects;

namespace Localization.Domain.Entities;

public sealed class Localization : Entity
{
    protected Localization() {}

    public string AddedBy { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IBGECode IBGECode { get; private set; } = new(string.Empty);

    public State State { get; private set; } = new(string.Empty);

    public ZipCode ZipCode { get; private set; } = new(string.Empty);

    private Localization(
        string ibgeCode
        , string state
        , string zipCode
        , string userFullName)
    {
        this.IBGECode = ibgeCode;
        this.State = state;
        this.ZipCode = zipCode;
        this.CreatedAt = DateTime.UtcNow;
        this.AddedBy = userFullName;
    }

    public static Localization Create(string ibgeCode
        , string state
        , string zipCode
        , string userFullName)
        => new(ibgeCode, state, zipCode, userFullName);
}