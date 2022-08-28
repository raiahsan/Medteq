using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class provider_unavailability_column_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "ProviderUnavailability");

            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "ProviderUnavailability");

            migrationBuilder.DropColumn(
                name: "ToTime",
                table: "ProviderUnavailability");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ProviderUnavailability",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDateTime",
                table: "ProviderUnavailability",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDateTime",
                table: "ProviderUnavailability",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ProviderUnavailability");

            migrationBuilder.DropColumn(
                name: "FromDateTime",
                table: "ProviderUnavailability");

            migrationBuilder.DropColumn(
                name: "ToDateTime",
                table: "ProviderUnavailability");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "ProviderUnavailability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FromTime",
                table: "ProviderUnavailability",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ToTime",
                table: "ProviderUnavailability",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
