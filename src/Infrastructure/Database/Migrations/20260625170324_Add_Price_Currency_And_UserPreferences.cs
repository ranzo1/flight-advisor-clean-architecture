using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class Add_Price_Currency_And_UserPreferences : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "price_currency",
            schema: "public",
            table: "watches",
            type: "text",
            nullable: false,
            defaultValue: "EUR");

        migrationBuilder.CreateTable(
            name: "user_preferences",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                wrist_circumference_cm = table.Column<decimal>(type: "numeric", nullable: false),
                budget_amount = table.Column<decimal>(type: "numeric", nullable: false),
                budget_currency = table.Column<string>(type: "text", nullable: false),
                preferred_styles = table.Column<string>(type: "text", nullable: false),
                movement_preference = table.Column<string>(type: "text", nullable: true),
                preferred_brands = table.Column<string>(type: "text", nullable: false),
                preferred_occasions = table.Column<string>(type: "text", nullable: false),
                preferred_dial_colors = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table => table.PrimaryKey("pk_user_preferences", x => x.id));

        migrationBuilder.CreateIndex(
            name: "ix_user_preferences_user_id",
            schema: "public",
            table: "user_preferences",
            column: "user_id",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "user_preferences",
            schema: "public");

        migrationBuilder.DropColumn(
            name: "price_currency",
            schema: "public",
            table: "watches");
    }
}
