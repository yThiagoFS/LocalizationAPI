using Localization.Domain.ValueObjects;

namespace Localization.Domain.Entities;

public class User : Entity 
{
    protected User() {}

    public Name Name { get; }

    public Email Email { get; }

    private User(
        string name
        , string email)
    {
        this.Name = name;
        this.Email = email;
    }

    public static User Create(string name, string email) 
        => new(name, email);
}