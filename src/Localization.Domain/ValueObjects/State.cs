namespace Localization.Domain.ValueObjects;

public sealed record State : ValueObject
{
    const string RegexPattern = "^[a-zA-Z]+$";

    public string Acronym { get; }

    public State(string acronym)
    {
        IsValid(acronym);

        this.Acronym = acronym.ToUpper();
    }

    public static implicit operator string(State state) => state.Acronym;

    public static implicit operator State(string acronym) => new(acronym);

    public override string ToString() => this.Acronym;

    private void IsValid(string acronym) 
    {
        ThrowIfNullOrEmpty(acronym, "State cannot be null or empty.");

        ThrowIfInvalidRegex(acronym, RegexPattern, "Only letters are avaliable for the state.");

        if(acronym.Length != 2) throw new Exception("Invalid state, use the acronym of the state.");
    }
} 