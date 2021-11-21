using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class modelchanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PictureAccess_PhotoId",
                table: "PictureAccess");

            migrationBuilder.CreateIndex(
                name: "IX_PictureAccess_PhotoId",
                table: "PictureAccess",
                column: "PhotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PictureAccess_PhotoId",
                table: "PictureAccess");

            migrationBuilder.CreateIndex(
                name: "IX_PictureAccess_PhotoId",
                table: "PictureAccess",
                column: "PhotoId",
                unique: true);
        }
    }
}
