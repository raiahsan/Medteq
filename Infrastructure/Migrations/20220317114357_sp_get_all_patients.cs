using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class sp_get_all_patients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[sp_GetPatients]
@firstName VARCHAR(50) NULL,
@lastName VARCHAR(50) NULL,
@patientID INT NULL,
@pageSize INT = 10,
@pageIndex INT = 1,
@sortColumn varchar(50) = 'CreatedDate',
@sortDirection varchar(50) = 'DESC',
@dateOfBirth datetime
AS
BEGIN
    SELECT COUNT(*) AS TotalRows FROM Patient p
    WHERE (@firstName IS NULL OR p.FirstName = @firstName) AND (@lastName IS NULL OR p.LastName = @lastName) AND (@patientID IS NULL OR p.ID = @patientID) AND (@dateOfBirth IS NULL OR p.DOB = @dateOfBirth)
    SELECT p.* FROM Patient p
    WHERE (@firstName IS NULL OR p.FirstName = @firstName) AND (@lastName IS NULL OR p.LastName = @lastName) AND (@patientID IS NULL OR p.ID = @patientID) AND (@dateOfBirth IS NULL OR p.DOB = @dateOfBirth)
    ORDER BY
    -- FirstName
    CASE WHEN @sortColumn = 'FirstName'AND @sortDirection = 'ASC' THEN p.FirstName END,
    CASE WHEN @sortColumn = 'FirstName' AND @sortDirection = 'DESC' THEN p.FirstName END DESC,
    -- LastName
    CASE WHEN @sortColumn = 'LastName' AND @sortDirection = 'ASC' THEN p.LastName END,
    CASE WHEN @sortColumn = 'LastName' AND @sortDirection = 'DESC' THEN p.LastName END DESC,
    -- CreatedDate
    CASE WHEN @sortColumn = 'CreatedDate' AND @sortDirection = 'ASC' THEN p.CreatedDate END,
    CASE WHEN @sortColumn = 'CreatedDate' AND @sortDirection = 'DESC' THEN p.CreatedDate END DESC
    OFFSET ((@pageIndex - 1) * @pageSize) Rows FETCH NEXT @pageSize ROWS ONLY
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP Procedure [dbo].[sp_GetPatients]");
        }
    }
}
