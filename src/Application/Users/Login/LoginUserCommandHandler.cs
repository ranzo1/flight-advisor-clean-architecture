using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Users;
using Domain.Users.ValueObjects;
using SharedKernel;

namespace Application.Users.Login;

internal sealed class LoginUserCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenProvider jwtTokenProvider) : ICommandHandler<LoginUserCommand, TokenResponse>
{
    public async Task<Result<TokenResponse>> Handle(
        LoginUserCommand command,
        CancellationToken cancellationToken)
    {
        Result<Email> emailResult = Email.Create(command.Email);
        if (emailResult.IsFailure)
        {
            return Result.Failure<TokenResponse>(UserErrors.InvalidCredentials);
        }

        User? user = await userRepository.GetByEmailAsync(emailResult.Value, cancellationToken);
        if (user is null)
        {
            return Result.Failure<TokenResponse>(UserErrors.InvalidCredentials);
        }

        if (!passwordHasher.Verify(command.Password, user.PasswordHash))
        {
            return Result.Failure<TokenResponse>(UserErrors.InvalidCredentials);
        }

        string token = jwtTokenProvider.Generate(user);

        return new TokenResponse(token);
    }
}
