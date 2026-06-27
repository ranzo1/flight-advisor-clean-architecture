using Domain.Users;
using Domain.Watches.Enums;
using Domain.Watches.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Infrastructure.Database.Configurations;

internal sealed class UserPreferencesConfiguration : IEntityTypeConfiguration<UserPreferences>
{
    private static readonly JsonSerializerOptions JsonOptions = new();

    private static ValueComparer<List<T>> ListComparer<T>() =>
        new(
            (a, b) => a != null && b != null && a.SequenceEqual(b),
            v => v.Aggregate(0, (a, b) => HashCode.Combine(a, b!.GetHashCode())),
            v => v.ToList());

    public void Configure(EntityTypeBuilder<UserPreferences> builder)
    {
        builder.HasKey(p => p.Id);

        builder.ToTable("user_preferences");

        builder.Property(p => p.UserId).HasColumnName("user_id").IsRequired();
        builder.HasIndex(p => p.UserId).IsUnique();

        builder.ComplexProperty(p => p.WristCircumference,
            b => b.Property(w => w.Value).HasColumnName("wrist_circumference_cm"));

        builder.ComplexProperty(p => p.Budget, b =>
        {
            b.Property(x => x.Amount).HasColumnName("budget_amount");
            b.Property(x => x.Currency).HasColumnName("budget_currency");
        });

        builder.Property(p => p.PreferredStyles)
            .HasConversion(
                v => JsonSerializer.Serialize(v.Select(s => s.ToString()).ToList(), JsonOptions),
                v => JsonSerializer.Deserialize<List<string>>(v, JsonOptions)!
                    .Select(Enum.Parse<WatchStyle>).ToList())
            .HasColumnName("preferred_styles")
            .HasColumnType("text")
            .Metadata.SetValueComparer(ListComparer<WatchStyle>());

        builder.Property(p => p.MovementPreference)
            .HasConversion<string?>()
            .HasColumnName("movement_preference");

        builder.Property(p => p.PreferredBrands)
            .HasConversion(
                v => JsonSerializer.Serialize(v.Select(b => b.Value).ToList(), JsonOptions),
                v => JsonSerializer.Deserialize<List<string>>(v, JsonOptions)!
                    .Select(s => Brand.Create(s).Value).ToList())
            .HasColumnName("preferred_brands")
            .HasColumnType("text")
            .Metadata.SetValueComparer(ListComparer<Brand>());

        builder.Property(p => p.PreferredOccasions)
            .HasConversion(
                v => JsonSerializer.Serialize(v.Select(o => o.ToString()).ToList(), JsonOptions),
                v => JsonSerializer.Deserialize<List<string>>(v, JsonOptions)!
                    .Select(Enum.Parse<WatchOccasion>).ToList())
            .HasColumnName("preferred_occasions")
            .HasColumnType("text")
            .Metadata.SetValueComparer(ListComparer<WatchOccasion>());

        builder.Property(p => p.PreferredDialColors)
            .HasConversion(
                v => JsonSerializer.Serialize(v.Select(d => d.Value).ToList(), JsonOptions),
                v => JsonSerializer.Deserialize<List<string>>(v, JsonOptions)!
                    .Select(s => DialColor.Create(s).Value).ToList())
            .HasColumnName("preferred_dial_colors")
            .HasColumnType("text")
            .Metadata.SetValueComparer(ListComparer<DialColor>());
    }
}
