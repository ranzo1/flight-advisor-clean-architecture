namespace Infrastructure.Database.Seed;

public static class SeedingExtensions
{
    public static void SeedDatabase(this ApplicationDbContext context) =>
        DatabaseSeeder.Seed(context);
}
