using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureMetadataPictureId",
                table: "Picture",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_PictureMetadataPictureId",
                table: "Picture",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_PictureMetadata_PictureMetadataPictureId",
                table: "Picture",
                column: "ID",
                principalTable: "PictureMetadata",
                principalColumn: "PictureId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_PictureMetadata_PictureMetadataPictureId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_PictureMetadataPictureId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "PictureMetadataPictureId",
                table: "Picture");
        }
    }
}
