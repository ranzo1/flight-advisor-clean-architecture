using Application.Abstractions.Messaging;
using Application.Watches.BrowseWatches;

namespace Application.Watches.GetWatchById;

public sealed record GetWatchByIdQuery(Guid Id) : IQuery<WatchResponse>;
