using Localization.Domain.ValueObjects;

namespace Localization.Domain.Entities;

public sealed class Localization : Entity
{
    protected Localization() {}

    public Name AddedBy { get; private set; } 

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IBGECode IBGECode { get; private set; } 

    public State State { get; private set; } 

    public ZipCode ZipCode { get; private set; } 

    private Localization(
        string ibgeCode
        , string state
        , string zipCode
        , string name)
    {
        this.IBGECode = ibgeCode;
        this.State = state;
        this.ZipCode = zipCode;
        this.CreatedAt = DateTime.UtcNow;
        this.AddedBy = name;
    }

    public static Localization Create(string ibgeCode
        , string state
        , string zipCode
        , string name)
        => new(ibgeCode, state, zipCode, name);
}