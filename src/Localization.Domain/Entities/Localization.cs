using Localization.Domain.ValueObjects;

namespace Localization.Domain.Entities;

public sealed class Localization : Entity
{
    public string AddedBy { get; }

    public DateTime CreatedAt { get; }

    public IBGECode IBGECode { get; }

    public State State { get; }

    public ZipCode ZipCode { get; }

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