using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class foreignkey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_UserInfo_UserInfoUserId1",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_UserInfoUserId1",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "UserInfoUserId1",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "UserInfoUserId",
                table: "Picture");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Picture",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_Owner",
                table: "Picture",
                column: "Owner");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_UserInfo_Owner",
                table: "Picture",
                column: "Owner",
                principalTable: "UserInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_UserInfo_Owner",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_Owner",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Picture");

            migrationBuilder.AddColumn<string>(
                name: "UserInfoUserId",
                table: "Picture",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_UserInfoUserId",
                table: "Picture",
                column: "UserInfoUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_UserInfo_UserInfoUserId",
                table: "Picture",
                column: "UserInfoUserId",
                principalTable: "UserInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
