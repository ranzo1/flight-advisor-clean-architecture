using Domain.Users;

namespace Application.Abstractions.Authentication;

public interface IJwtTokenProvider
{
    string Generate(User user);
}
