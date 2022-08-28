using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class User_table_change_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CreatedBy",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ModifiedBy",
                table: "User");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedBy",
                table: "User",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_ModifiedBy",
                table: "User",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User",
                table: "User",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User1",
                table: "User",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
