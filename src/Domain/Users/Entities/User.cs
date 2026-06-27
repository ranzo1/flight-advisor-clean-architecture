using Domain.Users.Enums;
using Domain.Users.ValueObjects;
using SharedKernel;

namespace Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, Email email, Name name, PasswordHash passwordHash, Role role, bool hasPublicProfile)
        : base(id)
    {
        Email = email;
        Name = name;
        PasswordHash = passwordHash;
        Role = role;
        HasPublicProfile = hasPublicProfile;
    }

    private User()
    {
    }

    public Email Email { get; private set; }
    public Name Name { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public Role Role { get; private set; }
    public bool HasPublicProfile { get; set; }

    public static User Create(Email email, Name name, PasswordHash passwordHash, Role role, bool hasPublicProfile)
    {
        var user = new User(Guid.NewGuid(), email, name, passwordHash, role, hasPublicProfile);

        user.Raise(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}
