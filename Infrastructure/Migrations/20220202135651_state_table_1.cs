using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class state_table_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "ID",
                keyValue: 7,
                column: "Name",
                value: "Connecticut1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "ID",
                keyValue: 7,
                column: "Name",
                value: "Connecticut");
        }
    }
}
