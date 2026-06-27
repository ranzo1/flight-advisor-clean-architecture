using SharedKernel;

namespace Domain.Users.ValueObjects;

public sealed record WristCircumference
{
    public const decimal MinCm = 10m;
    public const decimal MaxCm = 30m;

    private WristCircumference(decimal value) => Value = value;

    private WristCircumference()
    {
    }

    public decimal Value { get; private set; }

    public static Result<WristCircumference> Create(decimal value)
    {
        if (value < MinCm || value > MaxCm)
        {
            return Result.Failure<WristCircumference>(UserPreferencesErrors.InvalidWristCircumference);
        }

        return new WristCircumference(value);
    }
}
