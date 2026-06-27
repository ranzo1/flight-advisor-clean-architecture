namespace Domain.Users;

public interface IUserPreferencesRepository
{
    Task<UserPreferences?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    void Add(UserPreferences preferences);
}
