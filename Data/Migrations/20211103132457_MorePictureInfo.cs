using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class MorePictureInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Geolocation",
                table: "Picture",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Picture",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Geolocation",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Picture");
        }
    }
}
