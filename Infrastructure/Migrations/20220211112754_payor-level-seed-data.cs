using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class payorlevelseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PayorLevel",
                columns: new[] { "ID", "Active", "Name" },
                values: new object[] { 1, true, "Primary" });

            migrationBuilder.InsertData(
                table: "PayorLevel",
                columns: new[] { "ID", "Active", "Name" },
                values: new object[] { 2, true, "Secondary" });

            migrationBuilder.InsertData(
                table: "PayorLevel",
                columns: new[] { "ID", "Active", "Name" },
                values: new object[] { 3, true, "Tertiary" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PayorLevel",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PayorLevel",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PayorLevel",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
