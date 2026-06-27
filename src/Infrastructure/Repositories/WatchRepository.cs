using Domain.Watches;
using Domain.Watches.Entities;
using Domain.Watches.ValueObjects;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class WatchRepository(ApplicationDbContext context) : IWatchRepository
{
    public Task<Watch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        context.Watches.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Watch>> BrowseAsync(WatchFilter filter, CancellationToken cancellationToken = default)
    {
        IQueryable<Watch> query = context.Watches.AsQueryable();

        if (filter.Style.HasValue)
        {
            query = query.Where(w => w.Style == filter.Style.Value);
        }

        if (filter.Movement.HasValue)
        {
            query = query.Where(w => w.Movement == filter.Movement.Value);
        }

        if (filter.PriceRange is not null)
        {
            query = query.Where(w =>
                w.Price.Amount >= filter.PriceRange.Min &&
                w.Price.Amount <= filter.PriceRange.Max);
        }

        return await query.ToListAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default) =>
        context.Watches.AnyAsync(w => w.Id == id, cancellationToken);
}
