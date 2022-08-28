using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class State_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "PatientPayorEligibilityDetail");

            migrationBuilder.DropColumn(
                name: "InsuredState",
                table: "PatientPayor");

            migrationBuilder.DropColumn(
                name: "State",
                table: "PatientContact");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Branch");

            migrationBuilder.RenameColumn(
                name: "BillingState",
                table: "Lead",
                newName: "fk_BillingStateID");

            migrationBuilder.AddColumn<int>(
                name: "fk_StateID",
                table: "PatientPayorEligibilityDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_InsuredStateID",
                table: "PatientPayor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_StateID",
                table: "PatientContact",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PatientAddress",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "fk_StateID",
                table: "Branch",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayorEligibilityDetail_fk_StateID",
                table: "PatientPayorEligibilityDetail",
                column: "fk_StateID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayor_fk_InsuredStateID",
                table: "PatientPayor",
                column: "fk_InsuredStateID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientContact_fk_StateID",
                table: "PatientContact",
                column: "fk_StateID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAddress_fk_StateID",
                table: "PatientAddress",
                column: "fk_StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_fk_BillingStateID",
                table: "Lead",
                column: "fk_BillingStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_fk_StateID",
                table: "Branch",
                column: "fk_StateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_State",
                table: "Branch",
                column: "fk_StateID",
                principalTable: "State",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_BillingState",
                table: "Lead",
                column: "fk_BillingStateID",
                principalTable: "State",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAddress_State",
                table: "PatientAddress",
                column: "fk_StateID",
                principalTable: "State",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientContact_State",
                table: "PatientContact",
                column: "fk_StateID",
                principalTable: "State",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientPayor_State",
                table: "PatientPayor",
                column: "fk_InsuredStateID",
                principalTable: "State",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientPayorEligibilityDetail_State",
                table: "PatientPayorEligibilityDetail",
                column: "fk_StateID",
                principalTable: "State",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_State",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Lead_BillingState",
                table: "Lead");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAddress_State",
                table: "PatientAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientContact_State",
                table: "PatientContact");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientPayor_State",
                table: "PatientPayor");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientPayorEligibilityDetail_State",
                table: "PatientPayorEligibilityDetail");

            migrationBuilder.DropIndex(
                name: "IX_PatientPayorEligibilityDetail_fk_StateID",
                table: "PatientPayorEligibilityDetail");

            migrationBuilder.DropIndex(
                name: "IX_PatientPayor_fk_InsuredStateID",
                table: "PatientPayor");

            migrationBuilder.DropIndex(
                name: "IX_PatientContact_fk_StateID",
                table: "PatientContact");

            migrationBuilder.DropIndex(
                name: "IX_PatientAddress_fk_StateID",
                table: "PatientAddress");

            migrationBuilder.DropIndex(
                name: "IX_Lead_fk_BillingStateID",
                table: "Lead");

            migrationBuilder.DropIndex(
                name: "IX_Branch_fk_StateID",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "fk_StateID",
                table: "PatientPayorEligibilityDetail");

            migrationBuilder.DropColumn(
                name: "fk_InsuredStateID",
                table: "PatientPayor");

            migrationBuilder.DropColumn(
                name: "fk_StateID",
                table: "PatientContact");

            migrationBuilder.DropColumn(
                name: "City",
                table: "PatientAddress");

            migrationBuilder.DropColumn(
                name: "fk_StateID",
                table: "Branch");

            migrationBuilder.RenameColumn(
                name: "fk_BillingStateID",
                table: "Lead",
                newName: "BillingState");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "PatientPayorEligibilityDetail",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuredState",
                table: "PatientPayor",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "PatientContact",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Branch",
                type: "char(2)",
                unicode: false,
                fixedLength: true,
                maxLength: 2,
                nullable: true);
        }
    }
}
