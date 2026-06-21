using Domain.Users;
using Domain.Users.Enums;
using Domain.Users.ValueObjects;
using FluentAssertions;

namespace Domain.UnitTests.Users;

public sealed class UserTests
{
    [Fact]
    public void Create_Should_CreateUser_WhenNameIsValid()
    {
        // Arrange
        Email email = Email.Create("test@test.com").Value;
        var name = new Name("Full Name");
        var passwordHash = new PasswordHash("hashed_password");

        // Act
        var user = User.Create(email, name, passwordHash, Role.User, true);

        // Assert
        user.Should().NotBeNull();
    }

    [Fact]
    public void Create_Should_RaiseDomainEvent_WhenNameIsValid()
    {
        // Arrange
        Email email = Email.Create("test@test.com").Value;
        var name = new Name("Full Name");
        var passwordHash = new PasswordHash("hashed_password");

        // Act
        var user = User.Create(email, name, passwordHash, Role.User, true);

        // Assert
        user.DomainEvents
            .Should().ContainSingle()
            .Which
            .Should().BeOfType<UserCreatedDomainEvent>();
    }
}
