using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class lookuptables_seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AddressType",
                columns: new[] { "ID", "Active", "TypeName" },
                values: new object[,]
                {
                    { 1, true, "Billing" },
                    { 2, true, "Shipping" }
                });

            migrationBuilder.InsertData(
                table: "ContactMethod",
                columns: new[] { "ID", "Active", "Name" },
                values: new object[,]
                {
                    { 1, true, "Primary" },
                    { 2, true, "Secondary" }
                });

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "ID", "Active", "Type" },
                values: new object[,]
                {
                    { 1, true, "Primary" },
                    { 2, true, "Secondary" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "ID", "Active", "Value" },
                values: new object[,]
                {
                    { 1, true, "Male" },
                    { 2, true, "Female" },
                    { 3, true, "Other" }
                });

            migrationBuilder.InsertData(
                table: "ICDCodeType",
                columns: new[] { "ID", "Active", "TypeName" },
                values: new object[,]
                {
                    { 1, true, "ICD-9" },
                    { 2, true, "ICD-10" }
                });

            migrationBuilder.InsertData(
                table: "LeadSource",
                columns: new[] { "ID", "Active", "Name" },
                values: new object[,]
                {
                    { 2, true, "Call" },
                    { 1, true, "Salesforce" }
                });

            migrationBuilder.InsertData(
                table: "LeadType",
                columns: new[] { "ID", "Active", "Name" },
                values: new object[,]
                {
                    { 1, true, "Primary" },
                    { 2, true, "Secondary" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatus",
                columns: new[] { "ID", "Active", "Value" },
                values: new object[,]
                {
                    { 1, true, "Married" },
                    { 2, true, "Single" },
                    { 3, true, "Divorced" },
                    { 4, true, "Widowed" }
                });

            migrationBuilder.InsertData(
                table: "RelationshipType",
                columns: new[] { "ID", "Active", "Type" },
                values: new object[,]
                {
                    { 5, true, "Wife" },
                    { 1, true, "Father" },
                    { 2, true, "Mother" },
                    { 3, true, "Brother" },
                    { 4, true, "Sister" },
                    { 6, true, "Husband" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AddressType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddressType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactMethod",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactMethod",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ICDCodeType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ICDCodeType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeadSource",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeadSource",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeadType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeadType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaritalStatus",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaritalStatus",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaritalStatus",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MaritalStatus",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RelationshipType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RelationshipType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RelationshipType",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RelationshipType",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RelationshipType",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RelationshipType",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
