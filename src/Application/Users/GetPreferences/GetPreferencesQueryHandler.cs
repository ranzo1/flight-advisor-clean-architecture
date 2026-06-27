using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Users;
using SharedKernel;

namespace Application.Users.GetPreferences;

internal sealed class GetPreferencesQueryHandler(
    IUserPreferencesRepository preferencesRepository,
    IUserContext userContext) : IQueryHandler<GetPreferencesQuery, UserPreferencesResponse>
{
    public async Task<Result<UserPreferencesResponse>> Handle(
        GetPreferencesQuery request,
        CancellationToken cancellationToken)
    {
        UserPreferences? preferences = await preferencesRepository.GetByUserIdAsync(
            userContext.UserId,
            cancellationToken);

        if (preferences is null)
        {
            return Result.Failure<UserPreferencesResponse>(UserPreferencesErrors.NotFound);
        }

        return new UserPreferencesResponse(
            preferences.WristCircumference.Value,
            preferences.Budget.Amount,
            preferences.PreferredStyles.Select(s => s.ToString()).ToList(),
            preferences.MovementPreference?.ToString(),
            preferences.PreferredBrands.Select(b => b.Value).ToList(),
            preferences.PreferredOccasions.Select(o => o.ToString()).ToList(),
            preferences.PreferredDialColors.Select(d => d.Value).ToList());
    }
}
