using Localization.Domain.ValueObjects;

namespace Localization.Domain.Entities;

public class Role : Entity 
{
    protected Role() {}
    
    public Name Name { get; }

    public ICollection<User> Users { get; private set; }= new List<User>();

    private Role(string name)   
        => this.Name = name;

    public static Role Create(string name)
        => new(name);
}