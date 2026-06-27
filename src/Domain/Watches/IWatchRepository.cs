using Domain.Watches.Entities;
using Domain.Watches.ValueObjects;

namespace Domain.Watches;

public interface IWatchRepository
{
    Task<Watch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Watch>> BrowseAsync(WatchFilter filter, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}
