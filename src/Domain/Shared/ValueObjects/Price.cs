using Domain.Watches.Errors;
using SharedKernel;

namespace Domain.Watches.ValueObjects;

public sealed record Price
{
    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    private Price()
    {
    }

    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = null!;

    public static Result<Price> Create(decimal amount, string currency = "EUR")
    {
        if (amount <= 0)
        {
            return Result.Failure<Price>(WatchErrors.InvalidPrice);
        }

        return new Price(amount, currency.ToUpperInvariant());
    }

    public bool IsWithinBudget(decimal budget) => Amount <= budget;
}
