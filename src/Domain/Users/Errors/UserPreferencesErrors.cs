using SharedKernel;

namespace Domain.Users;

public static class UserPreferencesErrors
{
    public static readonly Error NotFound = Error.NotFound(
        "UserPreferences.NotFound",
        "Preferences have not been set for this user");

    public static readonly Error InvalidWristCircumference = Error.Problem(
        "UserPreferences.InvalidWristCircumference",
        $"Wrist circumference must be between {ValueObjects.WristCircumference.MinCm} cm and {ValueObjects.WristCircumference.MaxCm} cm");

    public static readonly Error InvalidBudget = Error.Problem(
        "UserPreferences.InvalidBudget",
        "Budget must be greater than zero");
}
