using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class picturemetadatakey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddForeignKey(
                name: "FK_PictureMetadata_Picture_PictureId",
                table: "PictureMetadata",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PictureMetadata_Picture_PictureId",
                table: "PictureMetadata");

        }
    }
}
