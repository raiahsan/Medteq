using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class sp_getleads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[sp_GetLeads]
@firstName VARCHAR(50) NULL,
@lastName VARCHAR(50) NULL,
@email VARCHAR(150) Null,
@leadID INT NULL,
@pageSize INT = 10,
@pageIndex INT = 1,
@sortColumn VARCHAR(50) = 'CreatedDate',
@sortDirection VARCHAR(50) = 'DESC',
@dateOfBirth datetime
AS
BEGIN
    SELECT count (l.ID) AS TotalRows From Lead l
	LEFT JOIN Branch b
	ON b.ID= l.fk_BranchID
	LEFT JOIN Gender g
	ON g.ID =l.fk_GenderID
	Left JOIN LeadSource ls
	ON ls.ID=l.fk_LeadSourceID
	LEFT JOIN LeadType lt
	ON lt.ID =l.fk_LeadTypeID
	WHERE (@leadID IS NULL OR l.ID = @leadID) AND (@email IS NULL OR l.Email = @email) AND (@firstName IS NULL OR l.FirstName=FirstName) AND(@lastName IS NULL OR l.LastName=LastName)
	
    SELECT l.*,b.BranchName As Branch,g.Value As Gender ,ls.Name As LeadSource ,lt.Name As LeadType
	FROM Lead l
	LEFT JOIN Branch b
	ON b.ID= l.fk_BranchID
	LEFT JOIN Gender g
	ON g.ID =l.fk_GenderID
	Left JOIN LeadSource ls
	ON ls.ID=l.fk_LeadSourceID
	LEFT JOIN LeadType lt
	ON lt.ID =l.fk_LeadTypeID
	WHERE (@leadID IS NULL OR l.ID = @leadID) AND (@email IS NULL OR l.Email = @email) 
	 ORDER BY
    -- FirstName
    CASE WHEN @sortColumn = 'FirstName'AND @sortDirection = 'ASC' THEN l.FirstName END,
    CASE WHEN @sortColumn = 'FirstName' AND @sortDirection = 'DESC' THEN l.FirstName END DESC,
    -- LastName
    CASE WHEN @sortColumn = 'LastName' AND @sortDirection = 'ASC' THEN l.LastName END,
    CASE WHEN @sortColumn = 'LastName' AND @sortDirection = 'DESC' THEN l.LastName END DESC,
    -- CreatedDate
    CASE WHEN @sortColumn = 'CreatedDate' AND @sortDirection = 'ASC' THEN l.CreatedDate END,
    CASE WHEN @sortColumn = 'CreatedDate' AND @sortDirection = 'DESC' THEN l.CreatedDate END DESC
    OFFSET ((@pageIndex - 1) * @pageSize) Rows FETCH NEXT @pageSize ROWS ONLY
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP Procedure [dbo].[sp_GetLeads]");
        }
    }
}
