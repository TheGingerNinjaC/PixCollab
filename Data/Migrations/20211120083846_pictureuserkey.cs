using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class pictureuserkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Picture");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Picture",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_OwnerId",
                table: "Picture",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_UserInfo_OwnerId",
                table: "Picture",
                column: "OwnerId",
                principalTable: "UserInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_UserInfo_OwnerId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_OwnerId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Picture");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Picture",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
