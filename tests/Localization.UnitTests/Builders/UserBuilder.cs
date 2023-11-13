using Bogus;
using Localization.Domain.Entities;

namespace Localization.UnitTests.Builders;

public class UserBuilder : Faker<User> 
{
    public static User Build(bool isAdmin = true)  
        => new Faker<User>()
        .CustomInstantiator(f => User.Create(
            f.Name.FullName()
            , f.Person.Email
            , f.Internet.Password()
            , isAdmin ? AdminRole() : UserRole()
        ));

    private static List<Role> AdminRole()
        => new() { Role.Create("admin") };

    private static List<Role> UserRole()
        => new() { Role.Create("user") };
}