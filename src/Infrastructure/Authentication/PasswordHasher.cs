using Application.Abstractions.Authentication;
using Domain.Users.ValueObjects;

namespace Infrastructure.Authentication;

internal sealed class PasswordHasher : IPasswordHasher
{
    public PasswordHash Hash(string password) =>
        new(BCrypt.Net.BCrypt.HashPassword(password));

    public bool Verify(string password, PasswordHash passwordHash) =>
        BCrypt.Net.BCrypt.Verify(password, passwordHash.Value);
}
