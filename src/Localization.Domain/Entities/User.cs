using Localization.Domain.ValueObjects;

namespace Localization.Domain.Entities;

public sealed class User : Entity 
{
    protected User() {}

    public Name Name { get; private set; } = new(string.Empty);

    public Email Email { get; private set; } = new(string.Empty);

    public Password Password { get; private set; } = new(string.Empty);

    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; private set; }

    public ICollection<Role> Roles { get; private set; } = new List<Role>();

    private User(
        string name
        , string email
        , string password
        , Role role)
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.CreatedAt = DateTime.UtcNow;
        this.Roles.Add(role);
    }

    public static User Create(string name, string email, string password, Role role) 
        => new(name, email, password, role);

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