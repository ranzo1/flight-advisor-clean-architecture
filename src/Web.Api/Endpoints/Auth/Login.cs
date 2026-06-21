using Application.Users.Login;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Auth;

internal sealed class Login : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/login", async (
            LoginUserCommand command,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            Result<TokenResponse> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .AllowAnonymous()
        .WithTags(Tags.Auth);
    }
}
