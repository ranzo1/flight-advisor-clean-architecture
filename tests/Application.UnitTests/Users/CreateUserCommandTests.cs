using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Users.Create;
using Domain.Users;
using Domain.Users.ValueObjects;
using FluentAssertions;
using NSubstitute;
using SharedKernel;

namespace Application.UnitTests.Users;

public sealed class CreateUserCommandTests
{
    private static readonly CreateUserCommand Command = new("test@test.com", "FullName", "Password123", true);

    private readonly CreateUserCommandHandler _handler;
    private readonly IUserRepository _userRepositoryMock;
    private readonly IPasswordHasher _passwordHasherMock;
    private readonly IUnitOfWork _unitOfWorkMock;

    public CreateUserCommandTests()
    {
        _userRepositoryMock = Substitute.For<IUserRepository>();
        _passwordHasherMock = Substitute.For<IPasswordHasher>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();

        _passwordHasherMock.Hash(Arg.Any<string>()).Returns(new PasswordHash("hashed"));

        _handler = new CreateUserCommandHandler(
            _userRepositoryMock,
            _passwordHasherMock,
            _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenEmailIsInvalid()
    {
        // Arrange
        CreateUserCommand invalidCommand = Command with { Email = "invalid_email" };

        // Act
        Result<Guid> result = await _handler.Handle(invalidCommand, default);

        // Assert
        result.Error.Should().Be(EmailErrors.InvalidFormat);
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenEmailIsNotUnique()
    {
        // Arrange
        _userRepositoryMock.IsEmailUniqueAsync(Arg.Is<Email>(e => e.Value == Command.Email))
            .Returns(false);

        // Act
        Result<Guid> result = await _handler.Handle(Command, default);

        // Assert
        result.Error.Should().Be(UserErrors.EmailNotUnique);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccess_WhenCreateSucceeds()
    {
        // Arrange
        _userRepositoryMock.IsEmailUniqueAsync(Arg.Is<Email>(e => e.Value == Command.Email))
            .Returns(true);

        // Act
        Result<Guid> result = await _handler.Handle(Command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_CallRepository_WhenCreateSucceeds()
    {
        // Arrange
        _userRepositoryMock.IsEmailUniqueAsync(Arg.Is<Email>(e => e.Value == Command.Email))
            .Returns(true);

        // Act
        Result<Guid> result = await _handler.Handle(Command, default);

        // Assert
        _userRepositoryMock.Received(1).Insert(Arg.Is<User>(u => u.Id == result.Value));
    }

    [Fact]
    public async Task Handle_Should_CallUnitOfWork_WhenCreateSucceeds()
    {
        // Arrange
        _userRepositoryMock.IsEmailUniqueAsync(Arg.Is<Email>(e => e.Value == Command.Email))
            .Returns(true);

        // Act
        await _handler.Handle(Command, default);

        // Assert
        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}
