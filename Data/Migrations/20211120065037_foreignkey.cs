using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_UserInfo_UserInfoUserId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_UserInfoUserId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Picture");

            migrationBuilder.AlterColumn<string>(
                name: "UserInfoUserId",
                table: "Picture",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoUserId1",
                table: "Picture",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_UserInfoUserId1",
                table: "Picture",
                column: "UserInfoUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_UserInfo_UserInfoUserId1",
                table: "Picture",
                column: "UserInfoUserId1",
                principalTable: "UserInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserInfoUserId",
                table: "Picture",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Picture",
                type: "nvarchar(max)",
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
