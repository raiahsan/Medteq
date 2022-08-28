using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class payor_table_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Payor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Payor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsEDIPayer",
                table: "Payor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSupportingClaims",
                table: "Payor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSupportingEligibility",
                table: "Payor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Payor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Payor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PayorCode",
                table: "Payor",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payor");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Payor");

            migrationBuilder.DropColumn(
                name: "IsEDIPayer",
                table: "Payor");

            migrationBuilder.DropColumn(
                name: "IsSupportingClaims",
                table: "Payor");

            migrationBuilder.DropColumn(
                name: "IsSupportingEligibility",
                table: "Payor");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Payor");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Payor");

            migrationBuilder.DropColumn(
                name: "PayorCode",
                table: "Payor");
        }
    }
}
