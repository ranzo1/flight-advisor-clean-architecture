namespace Application.Watches.BrowseWatches;

public sealed record WatchResponse(
    Guid Id,
    string Brand,
    string Model,
    string ReferenceNumber,
    decimal CaseDiameterMm,
    decimal CaseThicknessMm,
    decimal LugWidthMm,
    decimal LugToLugMm,
    string Style,
    string Movement,
    string Occasion,
    decimal PriceEur,
    string DialColor,
    string CaseMaterial,
    string BraceletType,
    Uri ImageUrl,
    string? Description);
