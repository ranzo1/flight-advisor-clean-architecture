namespace Application.Users.GetPreferences;

public sealed record UserPreferencesResponse(
    decimal WristCircumferenceCm,
    decimal Budget,
    List<string> PreferredStyles,
    string? MovementPreference,
    List<string> PreferredBrands,
    List<string> PreferredOccasions,
    List<string> PreferredDialColors);
