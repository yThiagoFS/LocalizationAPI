using Localization.Domain.ValueObjects;

namespace Localization.Domain.Entities;

public sealed class User : Entity 
{
    protected User() {}

    public Name Name { get; private set; }

    public Email Email { get; private set; }

    public Password Password { get; private set; }

    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; private set; }

    public ICollection<Role> Roles { get; private set; } = new List<Role>();

    private User(
        string name
        , string email
        , string password
        , List<Role> roles)
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.CreatedAt = DateTime.UtcNow;
        this.Roles = roles;
    }

    public static User Create(string name, string email, string password, List<Role> roles) 
        => new(name, email, password, roles);

    public User Update(string name, string email, string pasword, List<Role> roles) 
    {
        this.Name = name;
        this.Email = email;
        this.Password = pasword;
        this.UpdatedAt = DateTime.UtcNow;
        this.Roles = roles;

        return this;
    }
}