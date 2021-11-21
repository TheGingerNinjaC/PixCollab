using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class modelchanges8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "UserInfoUserId",
                table: "PictureAccess");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserInfoUserId",
                table: "PictureAccess",
                type: "nvarchar(450)",
                nullable: true);

          
        }
    }
}
