using Domain.Watches.Entities;
using Domain.Watches.Enums;
using SharedKernel;

namespace Infrastructure.Database.Seed;

internal static class DatabaseSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Watches.Any())
        {
            return;
        }

        context.Watches.AddRange(CreateWatches());
        context.SaveChanges();
    }

    private static List<WatchAggregate> CreateWatches() =>
    [
        // ── Entry level €100–€500 ──────────────────────────────────────────
        Watch("Seiko", "SKX007", "SKX007K2",
            42, 13, 22, 46, WatchStyle.Diver, MovementType.Automatic, WatchOccasion.Everyday,
            199, "Black", CaseMaterial.Steel, BraceletType.Bracelet,
            "Iconic automatic diver with 200m water resistance and a proven 7S26 movement."),

        Watch("Seiko", "SARB033", "SARB033",
            38, 11, 20, 42, WatchStyle.Dress, MovementType.Automatic, WatchOccasion.Office,
            450, "White", CaseMaterial.Steel, BraceletType.Leather,
            "Elegant dress watch with an in-house 6R15 movement and sapphire crystal."),

        Watch("Casio", "G-Shock GA-2100", "GA-2100-1AER",
            48, 11, 24, 52, WatchStyle.Sport, MovementType.Quartz, WatchOccasion.Outdoor,
            110, "Black", CaseMaterial.Steel, BraceletType.Rubber,
            "Ultra-slim G-Shock with carbon core guard structure and shock resistance."),

        Watch("Orient", "Bambino V2", "FAC00004W0",
            40, 12, 20, 44, WatchStyle.Dress, MovementType.Automatic, WatchOccasion.Formal,
            160, "White", CaseMaterial.Steel, BraceletType.Leather,
            "Hand-winding capable dress watch with a domed crystal and polished case."),

        Watch("Orient", "Mako II", "FAA02004B9",
            41, 13, 22, 46, WatchStyle.Diver, MovementType.Automatic, WatchOccasion.Everyday,
            155, "Blue", CaseMaterial.Steel, BraceletType.Bracelet,
            "Reliable automatic diver with 200m water resistance and screw-down crown."),

        Watch("Tissot", "PRX", "T137.410.11.051.00",
            40, 8, 21, 44, WatchStyle.Integrated, MovementType.Quartz, WatchOccasion.Office,
            375, "Blue", CaseMaterial.Steel, BraceletType.Bracelet,
            "Sleek integrated bracelet watch inspired by 1970s cushion-case designs."),

        Watch("Tissot", "Everytime Swissmatic", "T109.407.16.051.00",
            38, 9, 20, 42, WatchStyle.Dress, MovementType.Automatic, WatchOccasion.Office,
            395, "Silver", CaseMaterial.Steel, BraceletType.Leather,
            "Swiss automatic everyday watch with a clean dial and ETA Swissmatic movement."),

        Watch("Casio", "Edifice EFR-303", "EFR-303L-1AVUEF",
            45, 10, 22, 48, WatchStyle.Sport, MovementType.Quartz, WatchOccasion.Everyday,
            130, "Black", CaseMaterial.Steel, BraceletType.Bracelet,
            "Chronograph sport watch with tachymeter bezel and 100m water resistance."),

        // ── Mid range €500–€2 000 ─────────────────────────────────────────
        Watch("Longines", "HydroConquest", "L3.781.4.96.6",
            41, 12, 21, 46, WatchStyle.Diver, MovementType.Automatic, WatchOccasion.Everyday,
            900, "Blue", CaseMaterial.Steel, BraceletType.Bracelet,
            "Swiss-made diver with 300m water resistance and a ceramic bezel."),

        Watch("Longines", "Master Collection", "L2.793.4.72.6",
            40, 10, 20, 44, WatchStyle.Dress, MovementType.Automatic, WatchOccasion.Formal,
            1350, "Silver", CaseMaterial.Steel, BraceletType.Leather,
            "Classic dress watch with moon phase complication and alligator strap."),

        Watch("Certina", "DS Action Diver", "C032.407.11.051.00",
            43, 13, 22, 47, WatchStyle.Diver, MovementType.Automatic, WatchOccasion.Outdoor,
            780, "Black", CaseMaterial.Steel, BraceletType.Bracelet,
            "Robust automatic diver featuring Certina's Double Security case system."),

        Watch("Hamilton", "Khaki Field Mechanical", "H69439931",
            38, 10, 20, 42, WatchStyle.Field, MovementType.Manual, WatchOccasion.Everyday,
            595, "Green", CaseMaterial.Steel, BraceletType.Canvas,
            "Military-inspired field watch with a hand-wound ETA 2801-2 movement."),

        Watch("Hamilton", "Jazzmaster Viewmatic", "H32515555",
            40, 11, 20, 44, WatchStyle.Dress, MovementType.Automatic, WatchOccasion.Office,
            795, "White", CaseMaterial.Steel, BraceletType.Leather,
            "Open-heart dress watch with a visible balance wheel through the dial."),

        Watch("Mido", "Ocean Star 200", "M042.430.11.051.00",
            42, 12, 22, 46, WatchStyle.Diver, MovementType.Automatic, WatchOccasion.Everyday,
            850, "Black", CaseMaterial.Steel, BraceletType.Bracelet,
            "COSC-certified chronometer diver with 200m water resistance."),

        Watch("Frederique Constant", "Classic Index", "FC-303M4S6",
            40, 10, 20, 44, WatchStyle.Dress, MovementType.Automatic, WatchOccasion.Formal,
            995, "Silver", CaseMaterial.Steel, BraceletType.Leather,
            "In-house automatic movement with a date display and sapphire caseback."),

        // ── Upper mid €2 000–€5 000 ──────────────────────────────────────
        Watch("Tudor", "Black Bay 58", "M79030B-0001",
            39, 12, 20, 44, WatchStyle.Diver, MovementType.Automatic, WatchOccasion.Everyday,
            3250, "Black", CaseMaterial.Steel, BraceletType.Bracelet,
            "Vintage-inspired diver based on the original 1958 reference. MT5402 movement."),

        Watch("Tudor", "Pelagos FXD", "M25707KN-0001",
            42, 14, 22, 48, WatchStyle.Diver, MovementType.Automatic, WatchOccasion.Outdoor,
            4300, "Blue", CaseMaterial.Titanium, BraceletType.Rubber,
            "Titanium professional diver developed with French naval commandos."),

        Watch("Oris", "Aquis Date", "01 733 7730 4135",
            43, 13, 22, 48, WatchStyle.Diver, MovementType.Automatic, WatchOccasion.Everyday,
            2300, "Blue", CaseMaterial.Steel, BraceletType.Bracelet,
            "Swiss-made diver with 300m water resistance and exhibition caseback."),

        Watch("Oris", "Big Crown Pointer Date", "01 754 7679 4061",
            40, 11, 20, 44, WatchStyle.Pilot, MovementType.Automatic, WatchOccasion.Everyday,
            2150, "Black", CaseMaterial.Steel, BraceletType.Leather,
            "Pilot's watch with an elegant pointer date hand and bi-directional crown."),

        Watch("Zenith", "Chronomaster Sport", "03.3100.3600/69.M3100",
            41, 13, 21, 47, WatchStyle.Sport, MovementType.Automatic, WatchOccasion.Everyday,
            4900, "White", CaseMaterial.Steel, BraceletType.Bracelet,
            "High-frequency chronograph with the legendary El Primero 3600 movement."),

        Watch("Nomos", "Tangente 35", "101",
            35, 7, 18, 38, WatchStyle.Dress, MovementType.Manual, WatchOccasion.Formal,
            2100, "White", CaseMaterial.Steel, BraceletType.Leather,
            "Bauhaus minimalism with an in-house Alpha hand-wound calibre."),

        Watch("Nomos", "Club Sport Neomatik", "759",
            42, 11, 21, 45, WatchStyle.Sport, MovementType.Automatic, WatchOccasion.Everyday,
            3400, "Blue", CaseMaterial.Steel, BraceletType.Nato,
            "Sporty automatic with 300m water resistance and the DUW 3001 movement."),

        // ── Luxury €5 000+ ────────────────────────────────────────────────
        Watch("Omega", "Seamaster 300m", "210.30.42.20.03.001",
            42, 13, 21, 48, WatchStyle.Diver, MovementType.Automatic, WatchOccasion.Everyday,
            5400, "Blue", CaseMaterial.Steel, BraceletType.Bracelet,
            "James Bond's diver with a Co-Axial Master Chronometer movement and ceramic bezel."),

        Watch("Omega", "Speedmaster Moonwatch", "310.30.42.50.01.001",
            42, 13, 21, 47, WatchStyle.Sport, MovementType.Manual, WatchOccasion.Everyday,
            6600, "Black", CaseMaterial.Steel, BraceletType.Bracelet,
            "The original Moon watch, hand-wound Calibre 3861 METAS certified."),

        Watch("Omega", "Constellation Co-Axial", "131.10.39.20.02.001",
            39, 10, 20, 44, WatchStyle.Integrated, MovementType.Automatic, WatchOccasion.Office,
            5900, "Silver", CaseMaterial.Steel, BraceletType.Bracelet,
            "Constellation with integrated Manhattan bracelet and Co-Axial Master Chronometer."),

        Watch("IWC", "Pilot Mark XX", "IW328201",
            40, 11, 20, 46, WatchStyle.Pilot, MovementType.Automatic, WatchOccasion.Everyday,
            5000, "Black", CaseMaterial.Steel, BraceletType.Leather,
            "Classic pilot's watch with anti-magnetic soft-iron inner case and Calibre 82100."),

        Watch("IWC", "Portugieser Automatic", "IW500712",
            42, 10, 21, 48, WatchStyle.Dress, MovementType.Automatic, WatchOccasion.Formal,
            8500, "Silver", CaseMaterial.Steel, BraceletType.Leather,
            "Elegant large dress watch with a 7-day power reserve and Pellaton winding."),

        Watch("Jaeger-LeCoultre", "Reverso Classic", "Q2788570",
            45, 9, 21, 45, WatchStyle.Dress, MovementType.Manual, WatchOccasion.Formal,
            8200, "Silver", CaseMaterial.Steel, BraceletType.Leather,
            "Art Deco icon with a reversible case protecting the dial during polo matches."),

        Watch("Rolex", "Submariner Date", "126610LN",
            41, 13, 21, 47, WatchStyle.Diver, MovementType.Automatic, WatchOccasion.Everyday,
            10500, "Black", CaseMaterial.Steel, BraceletType.Bracelet,
            "The definitive luxury diver, Calibre 3235 with Oyster Perpetual movement."),

        Watch("Rolex", "Datejust 36", "126200",
            36, 12, 20, 41, WatchStyle.Dress, MovementType.Automatic, WatchOccasion.Office,
            7550, "Blue", CaseMaterial.Steel, BraceletType.Bracelet,
            "Timeless dress watch with Jubilee bracelet and Calibre 3235 movement."),

        Watch("Patek Philippe", "Calatrava", "5227G-010",
            38, 8, 20, 43, WatchStyle.Dress, MovementType.Manual, WatchOccasion.Formal,
            28000, "Silver", CaseMaterial.Gold, BraceletType.Leather,
            "The purest expression of watchmaking — officer-style caseback, Calibre 215 PS."),
    ];

    private static WatchAggregate Watch(
        string brand, string model, string referenceNumber,
        decimal caseDiameterMm, decimal caseThicknessMm, decimal lugWidthMm, decimal lugToLugMm,
        WatchStyle style, MovementType movement, WatchOccasion occasion,
        decimal priceEur, string dialColor, CaseMaterial caseMaterial, BraceletType braceletType,
        string description)
    {
        Result<WatchAggregate> result = WatchAggregate.Create(
            brand, model, referenceNumber,
            caseDiameterMm, caseThicknessMm, lugWidthMm, lugToLugMm,
            style, movement, occasion,
            priceEur, dialColor, caseMaterial, braceletType,
            new Uri($"https://placehold.co/400x300?text={Uri.EscapeDataString($"{brand}+{model}")}"),
            description);

        if (result.IsFailure)
        {
            throw new InvalidOperationException($"Seed data error for {brand} {model}: {result.Error.Description}");
        }

        return result.Value;
    }
}
