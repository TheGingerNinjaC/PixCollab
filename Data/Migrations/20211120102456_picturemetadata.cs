using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class picturemetadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PictureId",
                table: "PictureMetadata",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PictureId",
                table: "PictureMetadata",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int));
               
        }
    }
}
