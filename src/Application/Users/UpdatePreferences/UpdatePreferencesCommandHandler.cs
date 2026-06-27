using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Domain.Users.ValueObjects;
using Domain.Watches.ValueObjects;
using SharedKernel;

namespace Application.Users.UpdatePreferences;

internal sealed class UpdatePreferencesCommandHandler(
    IUserPreferencesRepository preferencesRepository,
    IUserContext userContext,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdatePreferencesCommand>
{
    public async Task<Result> Handle(
        UpdatePreferencesCommand command,
        CancellationToken cancellationToken)
    {
        Result<WristCircumference> wristResult = WristCircumference.Create(command.WristCircumferenceCm);
        if (wristResult.IsFailure)
        {
            return Result.Failure(wristResult.Error);
        }

        Result<Price> budgetResult = Price.Create(command.Budget);
        if (budgetResult.IsFailure)
        {
            return Result.Failure(budgetResult.Error);
        }

        var brands = command.PreferredBrands
            .Select(b => Brand.Create(b))
            .Where(r => r.IsSuccess)
            .Select(r => r.Value)
            .ToList();

        var dialColors = command.PreferredDialColors
            .Select(d => DialColor.Create(d))
            .Where(r => r.IsSuccess)
            .Select(r => r.Value)
            .ToList();

        UserPreferences? existing = await preferencesRepository.GetByUserIdAsync(
            userContext.UserId,
            cancellationToken);

        if (existing is null)
        {
            var preferences = UserPreferences.Create(
                userContext.UserId,
                wristResult.Value,
                budgetResult.Value,
                command.PreferredStyles,
                command.MovementPreference,
                brands,
                command.PreferredOccasions,
                dialColors);

            preferencesRepository.Add(preferences);
        }
        else
        {
            existing.Update(
                wristResult.Value,
                budgetResult.Value,
                command.PreferredStyles,
                command.MovementPreference,
                brands,
                command.PreferredOccasions,
                dialColors);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
