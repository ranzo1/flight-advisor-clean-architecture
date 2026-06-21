using Domain.Users;
using Domain.Users.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.ComplexProperty(
            u => u.Email,
            b => b.Property(e => e.Value).HasColumnName("email"));

        builder.ComplexProperty(
            u => u.Name,
            b => b.Property(e => e.Value).HasColumnName("name"));

        builder.ComplexProperty(
            u => u.PasswordHash,
            b => b.Property(p => p.Value).HasColumnName("password_hash"));

        builder.Property(u => u.Role)
            .HasConversion<string>()
            .HasColumnName("role");
    }
}
