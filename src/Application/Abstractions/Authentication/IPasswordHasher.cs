using Domain.Users.ValueObjects;

namespace Application.Abstractions.Authentication;

public interface IPasswordHasher
{
    PasswordHash Hash(string password);

    bool Verify(string password, PasswordHash passwordHash);
}
