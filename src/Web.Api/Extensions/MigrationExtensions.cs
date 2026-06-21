using Infrastructure.Database;
using Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Extensions;

internal static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ApplicationDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();

        dbContext.SeedDatabase();
    }
}
