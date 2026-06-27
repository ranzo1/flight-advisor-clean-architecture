using Domain.Watches.Enums;
using Domain.Watches.ValueObjects;
using SharedKernel;

namespace Domain.Watches.Entities;

public sealed class Watch : Entity
{
    private Watch(
        Guid id,
        Brand brand,
        Model model,
        ReferenceNumber referenceNumber,
        WatchDimensions dimensions,
        WatchStyle style,
        MovementType movement,
        WatchOccasion occasion,
        Price price,
        DialColor dialColor,
        CaseMaterial caseMaterial,
        BraceletType braceletType,
        Uri imageUrl,
        Description? description)
        : base(id)
    {
        Brand = brand;
        Model = model;
        ReferenceNumber = referenceNumber;
        Dimensions = dimensions;
        Style = style;
        Movement = movement;
        Occasion = occasion;
        Price = price;
        DialColor = dialColor;
        CaseMaterial = caseMaterial;
        BraceletType = braceletType;
        ImageUrl = imageUrl;
        Description = description;
    }

    private Watch()
    {
    }

    public Brand Brand { get; private set; } = null!;
    public Model Model { get; private set; } = null!;
    public ReferenceNumber ReferenceNumber { get; private set; }
    public WatchDimensions Dimensions { get; private set; } = null!;
    public WatchStyle Style { get; private set; }
    public MovementType Movement { get; private set; }
    public WatchOccasion Occasion { get; private set; }
    public Price Price { get; private set; } = null!;
    public DialColor DialColor { get; private set; }
    public CaseMaterial CaseMaterial { get; private set; }
    public BraceletType BraceletType { get; private set; }
    public Uri ImageUrl { get; private set; } = new Uri("about:blank");
    public Description? Description { get; private set; }

    public static Result<Watch> Create(
        string brand,
        string model,
        string referenceNumber,
        decimal caseDiameterMm,
        decimal caseThicknessMm,
        decimal lugWidthMm,
        decimal lugToLugMm,
        WatchStyle style,
        MovementType movement,
        WatchOccasion occasion,
        decimal priceEur,
        string dialColor,
        CaseMaterial caseMaterial,
        BraceletType braceletType,
        Uri imageUrl,
        string? description)
    {
        Result<Brand> brandResult = Brand.Create(brand);
        if (brandResult.IsFailure)
        {
            return Result.Failure<Watch>(brandResult.Error);
        }

        Result<Model> modelResult = Model.Create(model);
        if (modelResult.IsFailure)
        {
            return Result.Failure<Watch>(modelResult.Error);
        }

        Result<ReferenceNumber> referenceNumberResult = ReferenceNumber.Create(referenceNumber);
        if (referenceNumberResult.IsFailure)
        {
            return Result.Failure<Watch>(referenceNumberResult.Error);
        }

        Result<WatchDimensions> dimensionsResult = WatchDimensions.Create(
            caseDiameterMm, caseThicknessMm, lugWidthMm, lugToLugMm);
        if (dimensionsResult.IsFailure)
        {
            return Result.Failure<Watch>(dimensionsResult.Error);
        }

        Result<Price> priceResult = Price.Create(priceEur);
        if (priceResult.IsFailure)
        {
            return Result.Failure<Watch>(priceResult.Error);
        }

        Result<DialColor> dialColorResult = DialColor.Create(dialColor);
        if (dialColorResult.IsFailure)
        {
            return Result.Failure<Watch>(dialColorResult.Error);
        }

        Description? watchDescription = string.IsNullOrWhiteSpace(description)
            ? null
            : new Description(description);

        return new Watch(
            Guid.NewGuid(),
            brandResult.Value,
            modelResult.Value,
            referenceNumberResult.Value,
            dimensionsResult.Value,
            style,
            movement,
            occasion,
            priceResult.Value,
            dialColorResult.Value,
            caseMaterial,
            braceletType,
            imageUrl,
            watchDescription);
    }

    public bool FitsWrist(decimal wristCircumferenceCm) =>
        Dimensions.FitsWrist(wristCircumferenceCm);

    public bool IsWithinBudget(decimal budget) =>
        Price.IsWithinBudget(budget);
}
