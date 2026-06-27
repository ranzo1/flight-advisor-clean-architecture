using Application.Users.UpdatePreferences;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Profile;

internal sealed class UpdatePreferences : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("profile/preferences", async (
            UpdatePreferencesCommand command,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .RequireAuthorization()
        .WithTags(Tags.Profile);
    }
}
