using Localization.Domain.ValueObjects;

namespace Localization.Domain.Entities;

public sealed class Localization : Entity
{
    public string IBGECode { get; }

    public string AddedBy { get; }

    public State State { get; }

    public ZipCode ZipCode { get; }

    public Localization(
        string ibgeCode
        , string state
        , string zipCode)
    {
        this.IBGECode = ibgeCode;
        this.State = state;
        this.ZipCode = zipCode;
    }
}
