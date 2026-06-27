using Domain.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class UserPreferencesRepository(ApplicationDbContext context) : IUserPreferencesRepository
{
    public Task<UserPreferences?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
        context.UserPreferences.FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);

    public void Add(UserPreferences preferences) => context.UserPreferences.Add(preferences);
}
