using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class sp_get_all_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[sp_GetUsers]
@email Varchar(150) Null,
@userID INT NULL,
@pageSize INT = 10,
@pageIndex INT = 1,
@active bit NULL,
@sortColumn varchar(50) = 'CreatedDate',
@sortDirection varchar(50) = 'DESC'
AS
BEGIN
	  SELECT count(distinct u.ID) AS TotalRows FROM [User]  u
	  inner join UserToRole UTR on u.ID = utr.fk_UserID 
	  inner join [Role] r on utr.fk_RoleID=r.ID
	  WHERE (@userID IS NULL OR u.ID = @userID) AND (@email IS NULL OR u.Email = @email) AND (@active IS NULL OR  u.Active= @active)

	  SELECT u.ID, u.FirstName, u.LastName, u.Email, u.CreatedDate, u.CreatedBy, u.ModifiedBy, u.ModifiedDate, u.Active, STRING_AGG(r.RoleName,',') As Roles
	  From [User] u
	  inner join UserToRole UTR on u.ID = utr.fk_UserID 
	  inner join [Role] r on utr.fk_RoleID=r.ID
	  WHERE (@userID IS NULL OR u.ID = @userID) AND (@email IS NULL OR u.Email = @email) AND (@active IS NULL OR u.Active= @active)
	  Group By u.ID, u.FirstName, u.LastName, u.Email, u.CreatedDate, u.CreatedBy, u.ModifiedBy, u.ModifiedDate, u.Active
	  ORDER BY
      -- Email
          CASE WHEN @sortColumn = 'Email' AND @sortDirection = 'ASC' THEN u.Email END,
          CASE WHEN @sortColumn = 'Email' AND @sortDirection = 'DESC' THEN u.Email END DESC,
      -- CreatedDate
		  CASE WHEN @sortColumn = 'CreatedDate' AND @sortDirection = 'ASC' THEN u.CreatedDate END,
		  CASE WHEN @sortColumn = 'CreatedDate' AND @sortDirection = 'DESC' THEN u.CreatedDate END DESC,

      -- Active 
          CASE WHEN @sortColumn = '' AND @sortDirection = 'ASC' THEN u.Active END,
		  CASE WHEN @sortColumn = '' AND @sortDirection = 'DESC' THEN u.Active END DESC
          OFFSET ((@pageIndex - 1) * @pageSize) Rows FETCH NEXT @pageSize ROWS ONLY    
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP Procedure [dbo].[sp_GetUsers]");
        }
    }
}
