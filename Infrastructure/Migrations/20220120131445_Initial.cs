using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityDirection",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityDirection", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ActivityStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApiLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestURL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IPAddress = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    RequestByURL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseStatusCode = table.Column<int>(type: "int", nullable: false),
                    RequestAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactMethod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMethod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityID = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    JSON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestUrl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    RequestJSON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ICDCodeType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICDCodeType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeadSource",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSource", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeadType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Payor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayorGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayorName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    PostalCode = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FaxNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SiteUrl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ContactFirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ContactMiddleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ContactLastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PayPercentage = table.Column<byte>(type: "tinyint", nullable: true),
                    AccountOnHold = table.Column<bool>(type: "bit", nullable: true),
                    GroupName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GroupNumber = table.Column<int>(type: "int", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PlanType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PriceTable = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ClaimPercentage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Submission = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TaxType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Pcn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Bin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RawData = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PayorLevel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayorLevel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderHubID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fk_ParentProviderID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Suffix = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address1 = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    PostalCode = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MobilePhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FaxNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    DoctorGroup = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    UPIN = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    MedicalID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    DEANumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    DEAExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LicenseExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StateMedicaidID = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    NPINumber = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    CommercialNumber = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    TaxonomyCode = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Specialty = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    IMSRxerID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    MarketDecile = table.Column<int>(type: "int", nullable: true),
                    DegreeDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Provider_Provider",
                        column: x => x.fk_ParentProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_BranchID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    PasswordRequestHash = table.Column<string>(type: "varchar(1500)", unicode: false, maxLength: 1500, nullable: false),
                    PasswordRequestDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_User",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User1",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    WorkflowDescription = table.Column<string>(type: "varchar(1500)", unicode: false, maxLength: 1500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowState",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowStateName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICDCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fk_ICDCodeTypeID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Diagnosis_ICDCodeType",
                        column: x => x.fk_ICDCodeTypeID,
                        principalTable: "ICDCodeType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderUnavailability",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_ProviderID = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    FromTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ToTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderUnavailability", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProviderUnavailbility_Provider",
                        column: x => x.fk_ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BranchNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TaxID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NPI = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    TaxonomyCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Region = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    PostalCode = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Fax = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branch_User",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branch_User1",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_EntityID = table.Column<int>(type: "int", nullable: false),
                    RecordID = table.Column<int>(type: "int", nullable: false),
                    fileURL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    fileType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fileSize = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.ID);
                    table.ForeignKey(
                        name: "FK_File_Entity",
                        column: x => x.fk_EntityID,
                        principalTable: "Entity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_File_User",
                        column: x => x.UploadedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderAvailability",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_ProviderID = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    FromTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ToTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderAvailability", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProviderAvailbility_Provider",
                        column: x => x.fk_ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderAvailbility_User",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderAvailbility_User1",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToRole",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_UserID = table.Column<int>(type: "int", nullable: false),
                    fk_RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserToRole_Role",
                        column: x => x.fk_RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserToRole_User",
                        column: x => x.fk_UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStep",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LabelAlias = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fk_WorkflowID = table.Column<int>(type: "int", nullable: false),
                    WorkflowSequence = table.Column<int>(type: "int", nullable: false),
                    DashboardSequence = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    FinalStep = table.Column<bool>(type: "bit", nullable: false),
                    RegressToStepID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStep", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkflowStep_Workflow",
                        column: x => x.fk_WorkflowID,
                        principalTable: "Workflow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowStep_WorkflowStep",
                        column: x => x.RegressToStepID,
                        principalTable: "WorkflowStep",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fk_BranchID = table.Column<int>(type: "int", nullable: true),
                    fk_MaritalStatusID = table.Column<int>(type: "int", nullable: true),
                    fk_GenderID = table.Column<int>(type: "int", nullable: true),
                    fk_LinkedPatientID = table.Column<int>(type: "int", nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FaxNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MobilePhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Suffix = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    DOD = table.Column<DateTime>(type: "date", nullable: true),
                    DateOfAdmission = table.Column<DateTime>(type: "date", nullable: true),
                    DateOfDischarge = table.Column<DateTime>(type: "date", nullable: true),
                    DateOfOnset = table.Column<DateTime>(type: "date", nullable: true),
                    StateOfAutoAccident = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SSN = table.Column<string>(type: "char(9)", unicode: false, fixedLength: true, maxLength: 9, nullable: true),
                    HoldAcct = table.Column<bool>(type: "bit", nullable: true),
                    Height = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Weight = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DiscountPct = table.Column<int>(type: "int", nullable: true),
                    AccountNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    HIPPASignatureOnFile = table.Column<bool>(type: "bit", nullable: true),
                    MobileVerifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EmailVerifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patient_Branch",
                        column: x => x.fk_BranchID,
                        principalTable: "Branch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Gender",
                        column: x => x.fk_GenderID,
                        principalTable: "Gender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_MaritalStatus",
                        column: x => x.fk_MaritalStatusID,
                        principalTable: "MaritalStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Patient",
                        column: x => x.fk_LinkedPatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_User",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_User1",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkflowStep",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_UserID = table.Column<int>(type: "int", nullable: false),
                    fk_WorkflowStepID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkflowStep", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserWorkflowStep_User",
                        column: x => x.fk_UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserWorkflowStep_WorkflowStep",
                        column: x => x.fk_WorkflowStepID,
                        principalTable: "WorkflowStep",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_PatientID = table.Column<int>(type: "int", nullable: false),
                    fk_ActivityTypeID = table.Column<int>(type: "int", nullable: false),
                    Trackable = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityType",
                        column: x => x.fk_ActivityTypeID,
                        principalTable: "ActivityType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_Patient",
                        column: x => x.fk_PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_User",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_User1",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_ProviderID = table.Column<int>(type: "int", nullable: false),
                    fk_PatientID = table.Column<int>(type: "int", nullable: false),
                    BookingStartDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    BookingEndDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ExternalSystemAppointmentID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    Rescheduled = table.Column<bool>(type: "bit", nullable: false),
                    RawData = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient",
                        column: x => x.fk_PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Provider",
                        column: x => x.fk_ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_User",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_User1",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fk_LeadTypeID = table.Column<int>(type: "int", nullable: false),
                    fk_LeadSourceID = table.Column<int>(type: "int", nullable: false),
                    fk_BranchID = table.Column<int>(type: "int", nullable: false),
                    fk_PatientID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    HomePhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    fk_GenderID = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BillingAddress1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BillingAddress2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BillingAddress3 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BillingCity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BillingState = table.Column<int>(type: "int", nullable: true),
                    MobilePhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    BillingPostalCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DoctorFirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DoctorLastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DoctorNPI = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    DateLastSeenByDoctor = table.Column<DateTime>(type: "date", nullable: true),
                    DiagnosisCode = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    LeadRawData = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lead_Branch",
                        column: x => x.fk_BranchID,
                        principalTable: "Branch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lead_Gender",
                        column: x => x.fk_GenderID,
                        principalTable: "Gender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lead_LeadSource",
                        column: x => x.fk_LeadSourceID,
                        principalTable: "LeadSource",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lead_LeadType",
                        column: x => x.fk_LeadTypeID,
                        principalTable: "LeadType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lead_Patient",
                        column: x => x.fk_PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientAddress",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_PatientID = table.Column<int>(type: "int", nullable: false),
                    fk_AddressTypeID = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fk_StateID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    ContactPersonName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientAddress_AddressType",
                        column: x => x.fk_AddressTypeID,
                        principalTable: "AddressType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientAddress_Patient",
                        column: x => x.fk_PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientContact",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_PatientID = table.Column<int>(type: "int", nullable: false),
                    fk_ContactTypeID = table.Column<int>(type: "int", nullable: false),
                    fk_RelationshipTypeID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    FaxNumber = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientContact", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientContact_ContactType",
                        column: x => x.fk_ContactTypeID,
                        principalTable: "ContactType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientContact_Patient",
                        column: x => x.fk_PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientContact_RelationshipType",
                        column: x => x.fk_RelationshipTypeID,
                        principalTable: "RelationshipType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientContact_User",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientContact_User1",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientDiagnosis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_PatientID = table.Column<int>(type: "int", nullable: false),
                    fk_DiagnosisID = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ShortDescription = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDiagnosis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientDiagnosis_Diagnosis",
                        column: x => x.fk_DiagnosisID,
                        principalTable: "Diagnosis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientDiagnosis_Patient",
                        column: x => x.fk_PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientDiagnosis_User",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientDiagnosis_User1",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientPayor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientPayorGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fk_PatientID = table.Column<int>(type: "int", nullable: false),
                    fk_PayorID = table.Column<int>(type: "int", nullable: false),
                    fk_PayorLevelID = table.Column<int>(type: "int", nullable: false),
                    fk_PolicyHolderGenderID = table.Column<int>(type: "int", nullable: true),
                    PolicyNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PolicyHolderName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PolicyHolderDOB = table.Column<DateTime>(type: "date", nullable: true),
                    GroupNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Bin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Pcn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NCDPDPolicyNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NCPDPGroupNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    InsuredFirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    InsuredLastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    InsuredPhone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    InsuredAddress1 = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    InsuredAddress2 = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    InsuredCity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    InsuredState = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    InsuredZip = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PolicyStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PolicyEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PayPercent = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Deductible = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    GroupName = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    PayorContact = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    InsVerified = table.Column<bool>(type: "bit", nullable: true),
                    InsVerifiedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    InsVerifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    VerificationType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RawData = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPayor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientPayor_Gender",
                        column: x => x.fk_PolicyHolderGenderID,
                        principalTable: "Gender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientPayor_Patient",
                        column: x => x.fk_PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientPayor_Payor",
                        column: x => x.fk_PayorID,
                        principalTable: "Payor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientPayor_PayorLevel",
                        column: x => x.fk_PayorLevelID,
                        principalTable: "PayorLevel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientProvider",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_PatientID = table.Column<int>(type: "int", nullable: false),
                    fk_ProviderTypeID = table.Column<int>(type: "int", nullable: false),
                    fk_ProviderID = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProvider", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientProvider_Patient",
                        column: x => x.fk_PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientProvider_Provider",
                        column: x => x.fk_ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientProvider_ProviderType",
                        column: x => x.fk_ProviderTypeID,
                        principalTable: "ProviderType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityEmail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_ActivityID = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Body = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Sender = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: false),
                    Recipients = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CC = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    BCC = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityEmail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Email_Activity",
                        column: x => x.fk_ActivityID,
                        principalTable: "Activity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityMessage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_ActivityID = table.Column<int>(type: "int", nullable: false),
                    fk_DirectionID = table.Column<int>(type: "int", nullable: false),
                    Sender = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Reipient = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Sent = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityMessage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Message_Activity",
                        column: x => x.fk_ActivityID,
                        principalTable: "Activity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_ActivityDirection",
                        column: x => x.fk_DirectionID,
                        principalTable: "ActivityDirection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityNote",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_ActivityID = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Note_Activity",
                        column: x => x.fk_ActivityID,
                        principalTable: "Activity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityPhoneCall",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_ActivityID = table.Column<int>(type: "int", nullable: false),
                    fk_DirectionID = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    LeftVoiceMail = table.Column<bool>(type: "bit", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityPhoneCall", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhoneCall_Activity",
                        column: x => x.fk_ActivityID,
                        principalTable: "Activity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneCall_ActivityDirection",
                        column: x => x.fk_DirectionID,
                        principalTable: "ActivityDirection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_ActivityID = table.Column<int>(type: "int", nullable: false),
                    fk_StatusID = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Due = table.Column<DateTime>(type: "datetime", nullable: false),
                    AssignedTo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTask", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Task_Activity",
                        column: x => x.fk_ActivityID,
                        principalTable: "Activity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_ActivityStatus",
                        column: x => x.fk_StatusID,
                        principalTable: "ActivityStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadContact",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_LeadID = table.Column<int>(type: "int", nullable: false),
                    fk_ContactMethodID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    MobileNumber = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    FaxNumber = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadContact", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeadContact_ContactMethod",
                        column: x => x.fk_ContactMethodID,
                        principalTable: "ContactMethod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeadContact_Lead",
                        column: x => x.fk_LeadID,
                        principalTable: "Lead",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowRecord",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_WorkflowID = table.Column<int>(type: "int", nullable: false),
                    fk_LeadID = table.Column<int>(type: "int", nullable: false),
                    fk_PatientID = table.Column<int>(type: "int", nullable: true),
                    fk_WorkflowStepID = table.Column<int>(type: "int", nullable: false),
                    ReturnToStepID = table.Column<int>(type: "int", nullable: false),
                    EnterStepUserID = table.Column<int>(type: "int", nullable: false),
                    EnterStepTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowRecord", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkflowRecord_Lead",
                        column: x => x.fk_LeadID,
                        principalTable: "Lead",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowRecord_Patient",
                        column: x => x.fk_PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowRecord_User",
                        column: x => x.EnterStepUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowRecord_Workflow",
                        column: x => x.fk_WorkflowID,
                        principalTable: "Workflow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowRecord_WorkflowStep",
                        column: x => x.fk_WorkflowStepID,
                        principalTable: "WorkflowStep",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientPayorEligibility",
                columns: table => new
                {
                    EligibilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EligibilityGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fk_PatientID = table.Column<int>(type: "int", nullable: true),
                    Fk_PatientPayorID = table.Column<int>(type: "int", nullable: true),
                    ProviderLastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ProviderFirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ProviderNPI = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ProviderPIN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ProviderTaxanomy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VerificationType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SubcriberLastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SubcriberFirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SubcriberMemberID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SubcriberSSN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SubscriberGroupNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DependentLastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DependentFirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DependentRelationship = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PatientGender = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PatientDOB = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IssueDate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateOfServiceFrom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateOfServiceTo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BatchName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ServiceCodes = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    Manual = table.Column<bool>(type: "bit", nullable: false),
                    EligibilityRequestData = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    EligiblityRawResponse = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPayorEligibility", x => x.EligibilityID);
                    table.ForeignKey(
                        name: "FK_PatientPayorEligibility_Patient",
                        column: x => x.fk_PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientPayorEligibility_PatientPayor",
                        column: x => x.Fk_PatientPayorID,
                        principalTable: "PatientPayor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientPayorEligibility_User",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientPayorEligibility_User1",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowRecordNote",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_WorkflowRecordID = table.Column<int>(type: "int", nullable: false),
                    fk_WorkflowStepID = table.Column<int>(type: "int", nullable: false),
                    fk_UserID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowRecordNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkflowRecordNote_User",
                        column: x => x.fk_UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowRecordNote_WorkflowRecord",
                        column: x => x.fk_WorkflowRecordID,
                        principalTable: "WorkflowRecord",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowRecordNote_WorkflowStep",
                        column: x => x.fk_WorkflowStepID,
                        principalTable: "WorkflowStep",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowRecordStateHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_WorkflowRecordID = table.Column<int>(type: "int", nullable: false),
                    fk_WorkflowStateID = table.Column<int>(type: "int", nullable: false),
                    EnterStateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnteredStateByUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowRecordStateHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkflowRecordStateHistory_User",
                        column: x => x.EnteredStateByUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowRecordStateHistory_WorkflowRecord",
                        column: x => x.fk_WorkflowRecordID,
                        principalTable: "WorkflowRecord",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowRecordStateHistory_WorkflowState",
                        column: x => x.fk_WorkflowStateID,
                        principalTable: "WorkflowState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowRecordUserLock",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_WorkflowRecordID = table.Column<int>(type: "int", nullable: false),
                    fk_UserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowRecordUserLock", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkflowRecordUserLock_User",
                        column: x => x.fk_UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowRecordUserLock_WorkflowRecord",
                        column: x => x.fk_WorkflowRecordID,
                        principalTable: "WorkflowRecord",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStepHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_WorkflowRecordID = table.Column<int>(type: "int", nullable: false),
                    fk_WorkflowStepID = table.Column<int>(type: "int", nullable: false),
                    EnterStepTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnterStepUserID = table.Column<int>(type: "int", nullable: false),
                    ExitStepTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ExitStepUserID = table.Column<int>(type: "int", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    StepNotes = table.Column<string>(type: "varchar(1500)", unicode: false, maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStepHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkflowStepHistory_User",
                        column: x => x.EnterStepUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowStepHistory_User1",
                        column: x => x.ExitStepUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowStepHistory_WorkflowRecord",
                        column: x => x.fk_WorkflowRecordID,
                        principalTable: "WorkflowRecord",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowStepHistory_WorkflowStep",
                        column: x => x.fk_WorkflowStepID,
                        principalTable: "WorkflowStep",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientPayorEligibilityDetail",
                columns: table => new
                {
                    EligibilityDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_PatientPayorEligiblityID = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    AddressLine2 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Dob = table.Column<DateTime>(type: "date", nullable: true),
                    Relationship = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    MemberID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EligibilityBegin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PlanText = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PlanType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PlanBegin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PlanNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GroupNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OtherInfo = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ReportText = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Note = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RawJsonData = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPayorEligibilityDetail", x => x.EligibilityDetailID);
                    table.ForeignKey(
                        name: "FK_PatientPayorEligibilityDetail_PatientPayorEligibility",
                        column: x => x.fk_PatientPayorEligiblityID,
                        principalTable: "PatientPayorEligibility",
                        principalColumn: "EligibilityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "Active", "RoleName" },
                values: new object[] { 1, true, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_CreatedBy",
                table: "Activity",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_fk_ActivityTypeID",
                table: "Activity",
                column: "fk_ActivityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_fk_PatientID",
                table: "Activity",
                column: "fk_PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ModifiedBy",
                table: "Activity",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEmail_fk_ActivityID",
                table: "ActivityEmail",
                column: "fk_ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMessage_fk_ActivityID",
                table: "ActivityMessage",
                column: "fk_ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMessage_fk_DirectionID",
                table: "ActivityMessage",
                column: "fk_DirectionID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityNote_fk_ActivityID",
                table: "ActivityNote",
                column: "fk_ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityPhoneCall_fk_ActivityID",
                table: "ActivityPhoneCall",
                column: "fk_ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityPhoneCall_fk_DirectionID",
                table: "ActivityPhoneCall",
                column: "fk_DirectionID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTask_fk_ActivityID",
                table: "ActivityTask",
                column: "fk_ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTask_fk_StatusID",
                table: "ActivityTask",
                column: "fk_StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_CreatedBy",
                table: "Appointment",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_fk_PatientID",
                table: "Appointment",
                column: "fk_PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_fk_ProviderID",
                table: "Appointment",
                column: "fk_ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ModifiedBy",
                table: "Appointment",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CreatedBy",
                table: "Branch",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_ModifiedBy",
                table: "Branch",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_fk_ICDCodeTypeID",
                table: "Diagnosis",
                column: "fk_ICDCodeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_File_fk_EntityID",
                table: "File",
                column: "fk_EntityID");

            migrationBuilder.CreateIndex(
                name: "IX_File_UploadedBy",
                table: "File",
                column: "UploadedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_fk_BranchID",
                table: "Lead",
                column: "fk_BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_fk_GenderID",
                table: "Lead",
                column: "fk_GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_fk_LeadSourceID",
                table: "Lead",
                column: "fk_LeadSourceID");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_fk_LeadTypeID",
                table: "Lead",
                column: "fk_LeadTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_fk_PatientID",
                table: "Lead",
                column: "fk_PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadContact_fk_ContactMethodID",
                table: "LeadContact",
                column: "fk_ContactMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadContact_fk_LeadID",
                table: "LeadContact",
                column: "fk_LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_CreatedBy",
                table: "Patient",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_fk_BranchID",
                table: "Patient",
                column: "fk_BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_fk_GenderID",
                table: "Patient",
                column: "fk_GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_fk_LinkedPatientID",
                table: "Patient",
                column: "fk_LinkedPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_fk_MaritalStatusID",
                table: "Patient",
                column: "fk_MaritalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ModifiedBy",
                table: "Patient",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAddress_fk_AddressTypeID",
                table: "PatientAddress",
                column: "fk_AddressTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAddress_fk_PatientID",
                table: "PatientAddress",
                column: "fk_PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientContact_CreatedBy",
                table: "PatientContact",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PatientContact_fk_ContactTypeID",
                table: "PatientContact",
                column: "fk_ContactTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientContact_fk_PatientID",
                table: "PatientContact",
                column: "fk_PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientContact_fk_RelationshipTypeID",
                table: "PatientContact",
                column: "fk_RelationshipTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientContact_ModifiedBy",
                table: "PatientContact",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_CreatedBy",
                table: "PatientDiagnosis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_fk_DiagnosisID",
                table: "PatientDiagnosis",
                column: "fk_DiagnosisID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_fk_PatientID",
                table: "PatientDiagnosis",
                column: "fk_PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_ModifiedBy",
                table: "PatientDiagnosis",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayor_fk_PatientID",
                table: "PatientPayor",
                column: "fk_PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayor_fk_PayorID",
                table: "PatientPayor",
                column: "fk_PayorID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayor_fk_PayorLevelID",
                table: "PatientPayor",
                column: "fk_PayorLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayor_fk_PolicyHolderGenderID",
                table: "PatientPayor",
                column: "fk_PolicyHolderGenderID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayorEligibility_CreatedBy",
                table: "PatientPayorEligibility",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayorEligibility_fk_PatientID",
                table: "PatientPayorEligibility",
                column: "fk_PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayorEligibility_Fk_PatientPayorID",
                table: "PatientPayorEligibility",
                column: "Fk_PatientPayorID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayorEligibility_ModifiedBy",
                table: "PatientPayorEligibility",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayorEligibilityDetail_fk_PatientPayorEligiblityID",
                table: "PatientPayorEligibilityDetail",
                column: "fk_PatientPayorEligiblityID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProvider_fk_PatientID",
                table: "PatientProvider",
                column: "fk_PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProvider_fk_ProviderID",
                table: "PatientProvider",
                column: "fk_ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProvider_fk_ProviderTypeID",
                table: "PatientProvider",
                column: "fk_ProviderTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_fk_ParentProviderID",
                table: "Provider",
                column: "fk_ParentProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderAvailability_CreatedBy",
                table: "ProviderAvailability",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderAvailability_fk_ProviderID",
                table: "ProviderAvailability",
                column: "fk_ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderAvailability_ModifiedBy",
                table: "ProviderAvailability",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderUnavailability_fk_ProviderID",
                table: "ProviderUnavailability",
                column: "fk_ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedBy",
                table: "User",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_ModifiedBy",
                table: "User",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRole_fk_RoleID",
                table: "UserToRole",
                column: "fk_RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRole_fk_UserID",
                table: "UserToRole",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflowStep_fk_UserID",
                table: "UserWorkflowStep",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflowStep_fk_WorkflowStepID",
                table: "UserWorkflowStep",
                column: "fk_WorkflowStepID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecord_EnterStepUserID",
                table: "WorkflowRecord",
                column: "EnterStepUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecord_fk_LeadID",
                table: "WorkflowRecord",
                column: "fk_LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecord_fk_PatientID",
                table: "WorkflowRecord",
                column: "fk_PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecord_fk_WorkflowID",
                table: "WorkflowRecord",
                column: "fk_WorkflowID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecord_fk_WorkflowStepID",
                table: "WorkflowRecord",
                column: "fk_WorkflowStepID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecordNote_fk_UserID",
                table: "WorkflowRecordNote",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecordNote_fk_WorkflowRecordID",
                table: "WorkflowRecordNote",
                column: "fk_WorkflowRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecordNote_fk_WorkflowStepID",
                table: "WorkflowRecordNote",
                column: "fk_WorkflowStepID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecordStateHistory_EnteredStateByUserID",
                table: "WorkflowRecordStateHistory",
                column: "EnteredStateByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecordStateHistory_fk_WorkflowRecordID",
                table: "WorkflowRecordStateHistory",
                column: "fk_WorkflowRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecordStateHistory_fk_WorkflowStateID",
                table: "WorkflowRecordStateHistory",
                column: "fk_WorkflowStateID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecordUserLock_fk_UserID",
                table: "WorkflowRecordUserLock",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowRecordUserLock_fk_WorkflowRecordID",
                table: "WorkflowRecordUserLock",
                column: "fk_WorkflowRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStep_fk_WorkflowID",
                table: "WorkflowStep",
                column: "fk_WorkflowID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStep_RegressToStepID",
                table: "WorkflowStep",
                column: "RegressToStepID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStepHistory_EnterStepUserID",
                table: "WorkflowStepHistory",
                column: "EnterStepUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStepHistory_ExitStepUserID",
                table: "WorkflowStepHistory",
                column: "ExitStepUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStepHistory_fk_WorkflowRecordID",
                table: "WorkflowStepHistory",
                column: "fk_WorkflowRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStepHistory_fk_WorkflowStepID",
                table: "WorkflowStepHistory",
                column: "fk_WorkflowStepID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityEmail");

            migrationBuilder.DropTable(
                name: "ActivityMessage");

            migrationBuilder.DropTable(
                name: "ActivityNote");

            migrationBuilder.DropTable(
                name: "ActivityPhoneCall");

            migrationBuilder.DropTable(
                name: "ActivityTask");

            migrationBuilder.DropTable(
                name: "ApiLog");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "ExceptionLog");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "LeadContact");

            migrationBuilder.DropTable(
                name: "PatientAddress");

            migrationBuilder.DropTable(
                name: "PatientContact");

            migrationBuilder.DropTable(
                name: "PatientDiagnosis");

            migrationBuilder.DropTable(
                name: "PatientPayorEligibilityDetail");

            migrationBuilder.DropTable(
                name: "PatientProvider");

            migrationBuilder.DropTable(
                name: "ProviderAvailability");

            migrationBuilder.DropTable(
                name: "ProviderUnavailability");

            migrationBuilder.DropTable(
                name: "UserToRole");

            migrationBuilder.DropTable(
                name: "UserWorkflowStep");

            migrationBuilder.DropTable(
                name: "WorkflowRecordNote");

            migrationBuilder.DropTable(
                name: "WorkflowRecordStateHistory");

            migrationBuilder.DropTable(
                name: "WorkflowRecordUserLock");

            migrationBuilder.DropTable(
                name: "WorkflowStepHistory");

            migrationBuilder.DropTable(
                name: "ActivityDirection");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "ActivityStatus");

            migrationBuilder.DropTable(
                name: "Entity");

            migrationBuilder.DropTable(
                name: "ContactMethod");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropTable(
                name: "RelationshipType");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "PatientPayorEligibility");

            migrationBuilder.DropTable(
                name: "ProviderType");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "WorkflowState");

            migrationBuilder.DropTable(
                name: "WorkflowRecord");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "ICDCodeType");

            migrationBuilder.DropTable(
                name: "PatientPayor");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "WorkflowStep");

            migrationBuilder.DropTable(
                name: "Payor");

            migrationBuilder.DropTable(
                name: "PayorLevel");

            migrationBuilder.DropTable(
                name: "LeadSource");

            migrationBuilder.DropTable(
                name: "LeadType");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Workflow");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "MaritalStatus");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
