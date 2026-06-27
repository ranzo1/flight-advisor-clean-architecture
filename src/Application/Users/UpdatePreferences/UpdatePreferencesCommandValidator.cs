using Domain.Users.ValueObjects;
using FluentValidation;

namespace Application.Users.UpdatePreferences;

internal sealed class UpdatePreferencesCommandValidator : AbstractValidator<UpdatePreferencesCommand>
{
    public UpdatePreferencesCommandValidator()
    {
        RuleFor(c => c.WristCircumferenceCm)
            .InclusiveBetween(WristCircumference.MinCm, WristCircumference.MaxCm);

        RuleFor(c => c.Budget)
            .GreaterThan(0);
    }
}
