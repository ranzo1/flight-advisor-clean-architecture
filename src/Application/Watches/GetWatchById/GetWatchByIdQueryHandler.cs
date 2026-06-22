using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Watches.BrowseWatches;
using Dapper;
using Domain.Watches.Errors;
using SharedKernel;
using System.Data;

namespace Application.Watches.GetWatchById;

internal sealed class GetWatchByIdQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetWatchByIdQuery, WatchResponse>
{
    public async Task<Result<WatchResponse>> Handle(
        GetWatchByIdQuery request,
        CancellationToken cancellationToken)
    {
        const string sql =
            """
            SELECT
                w.id                AS Id,
                w.brand             AS Brand,
                w.model             AS Model,
                w.reference_number  AS ReferenceNumber,
                w.case_diameter_mm  AS CaseDiameterMm,
                w.case_thickness_mm AS CaseThicknessMm,
                w.lug_width_mm      AS LugWidthMm,
                w.lug_to_lug_mm     AS LugToLugMm,
                w.style             AS Style,
                w.movement          AS Movement,
                w.occasion          AS Occasion,
                w.price_eur         AS PriceEur,
                w.dial_color        AS DialColor,
                w.case_material     AS CaseMaterial,
                w.bracelet_type     AS BraceletType,
                w.image_url         AS ImageUrl,
                w.description       AS Description
            FROM watches w
            WHERE w.id = @Id
            """;

        using IDbConnection connection = dbConnectionFactory.GetOpenConnection();

        WatchRow? row = await connection.QuerySingleOrDefaultAsync<WatchRow>(sql, new { request.Id });

        if (row is null)
        {
            return Result.Failure<WatchResponse>(WatchErrors.NotFound(request.Id));
        }

        return new WatchResponse(
            row.Id,
            row.Brand,
            row.Model,
            row.ReferenceNumber,
            row.CaseDiameterMm,
            row.CaseThicknessMm,
            row.LugWidthMm,
            row.LugToLugMm,
            row.Style,
            row.Movement,
            row.Occasion,
            row.PriceEur,
            row.DialColor,
            row.CaseMaterial,
            row.BraceletType,
            new Uri(row.ImageUrl),
            row.Description);
    }

#pragma warning disable S3459, S1144
    private sealed class WatchRow
    {
        public Guid Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string ReferenceNumber { get; set; } = null!;
        public decimal CaseDiameterMm { get; set; }
        public decimal CaseThicknessMm { get; set; }
        public decimal LugWidthMm { get; set; }
        public decimal LugToLugMm { get; set; }
        public string Style { get; set; } = null!;
        public string Movement { get; set; } = null!;
        public string Occasion { get; set; } = null!;
        public decimal PriceEur { get; set; }
        public string DialColor { get; set; } = null!;
        public string CaseMaterial { get; set; } = null!;
        public string BraceletType { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string? Description { get; set; }
    }
#pragma warning restore S3459, S1144
}
