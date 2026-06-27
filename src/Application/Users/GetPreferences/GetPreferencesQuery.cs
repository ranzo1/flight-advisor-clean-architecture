using Application.Abstractions.Messaging;

namespace Application.Users.GetPreferences;

public sealed record GetPreferencesQuery : IQuery<UserPreferencesResponse>;
