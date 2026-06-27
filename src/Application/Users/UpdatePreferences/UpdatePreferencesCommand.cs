using Application.Abstractions.Messaging;
using Domain.Watches.Enums;

namespace Application.Users.UpdatePreferences;

public sealed record UpdatePreferencesCommand(
    decimal WristCircumferenceCm,
    decimal Budget,
    List<WatchStyle> PreferredStyles,
    MovementType? MovementPreference,
    List<string> PreferredBrands,
    List<WatchOccasion> PreferredOccasions,
    List<string> PreferredDialColors) : ICommand;
