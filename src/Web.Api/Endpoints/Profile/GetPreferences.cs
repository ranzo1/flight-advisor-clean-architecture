using Application.Users.GetPreferences;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Profile;

internal sealed class GetPreferences : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("profile/preferences", async (
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new GetPreferencesQuery();

            Result<UserPreferencesResponse> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .RequireAuthorization()
        .WithTags(Tags.Profile);
    }
}
