using Domain.Users.ValueObjects;
using Domain.Watches.Enums;
using Domain.Watches.ValueObjects;
using SharedKernel;

namespace Domain.Users;

public sealed class UserPreferences : Entity
{
    private UserPreferences(
        Guid id,
        Guid userId,
        WristCircumference wristCircumference,
        Price budget,
        List<WatchStyle> preferredStyles,
        MovementType? movementPreference,
        List<Brand> preferredBrands,
        List<WatchOccasion> preferredOccasions,
        List<DialColor> preferredDialColors)
        : base(id)
    {
        UserId = userId;
        WristCircumference = wristCircumference;
        Budget = budget;
        PreferredStyles = preferredStyles;
        MovementPreference = movementPreference;
        PreferredBrands = preferredBrands;
        PreferredOccasions = preferredOccasions;
        PreferredDialColors = preferredDialColors;
    }

    private UserPreferences()
    {
    }

    public Guid UserId { get; private set; }
    public WristCircumference WristCircumference { get; private set; } = null!;
    public Price Budget { get; private set; } = null!;
    public List<WatchStyle> PreferredStyles { get; private set; } = [];
    public MovementType? MovementPreference { get; private set; }
    public List<Brand> PreferredBrands { get; private set; } = [];
    public List<WatchOccasion> PreferredOccasions { get; private set; } = [];
    public List<DialColor> PreferredDialColors { get; private set; } = [];

    public static UserPreferences Create(
        Guid userId,
        WristCircumference wristCircumference,
        Price budget,
        List<WatchStyle> preferredStyles,
        MovementType? movementPreference,
        List<Brand> preferredBrands,
        List<WatchOccasion> preferredOccasions,
        List<DialColor> preferredDialColors) =>
        new(
            Guid.NewGuid(),
            userId,
            wristCircumference,
            budget,
            preferredStyles,
            movementPreference,
            preferredBrands,
            preferredOccasions,
            preferredDialColors);

    public void Update(
        WristCircumference wristCircumference,
        Price budget,
        List<WatchStyle> preferredStyles,
        MovementType? movementPreference,
        List<Brand> preferredBrands,
        List<WatchOccasion> preferredOccasions,
        List<DialColor> preferredDialColors)
    {
        WristCircumference = wristCircumference;
        Budget = budget;
        PreferredStyles = preferredStyles;
        MovementPreference = movementPreference;
        PreferredBrands = preferredBrands;
        PreferredOccasions = preferredOccasions;
        PreferredDialColors = preferredDialColors;
    }
}
