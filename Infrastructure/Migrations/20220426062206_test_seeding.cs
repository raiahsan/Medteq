using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class test_seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Alabam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Alabama");
        }
    }
}
