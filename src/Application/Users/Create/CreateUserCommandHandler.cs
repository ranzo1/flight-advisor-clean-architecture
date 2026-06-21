using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Domain.Users.Enums;
using Domain.Users.ValueObjects;
using SharedKernel;

namespace Application.Users.Create;

internal sealed class CreateUserCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        Result<Email> emailResult = Email.Create(command.Email);
        if (emailResult.IsFailure)
        {
            return Result.Failure<Guid>(emailResult.Error);
        }

        Email email = emailResult.Value;
        if (!await userRepository.IsEmailUniqueAsync(email))
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }

        var name = new Name(command.Name);
        PasswordHash passwordHash = passwordHasher.Hash(command.Password);

        var user = User.Create(email, name, passwordHash, Role.User, command.HasPublicProfile);

        userRepository.Insert(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
