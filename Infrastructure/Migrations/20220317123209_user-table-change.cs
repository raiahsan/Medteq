using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class usertablechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    InverseCreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    InverseModifiedByUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.InverseCreatedByUserID, x.InverseModifiedByUserID });
                    table.ForeignKey(
                        name: "FK_UserUser_User_InverseCreatedByUserID",
                        column: x => x.InverseCreatedByUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_User_InverseModifiedByUserID",
                        column: x => x.InverseModifiedByUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_InverseModifiedByUserID",
                table: "UserUser",
                column: "InverseModifiedByUserID");
        }
    }
}
