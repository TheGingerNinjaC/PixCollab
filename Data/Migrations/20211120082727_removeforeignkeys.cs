using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class removeforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_UserInfo_Owner",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_PictureAccess_Picture_PictureID",
                table: "PictureAccess");

            migrationBuilder.DropForeignKey(
                name: "FK_PictureAccess_UserInfo_UserInfoUserId",
                table: "PictureAccess");

            migrationBuilder.DropIndex(
                name: "IX_PictureAccess_PictureID",
                table: "PictureAccess");

            migrationBuilder.DropIndex(
                name: "IX_PictureAccess_UserInfoUserId",
                table: "PictureAccess");

            migrationBuilder.DropIndex(
                name: "IX_Picture_Owner",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "PictureID",
                table: "PictureAccess");

            migrationBuilder.DropColumn(
                name: "UserInfoUserId",
                table: "PictureAccess");

            migrationBuilder.DropColumn(
                name: "test",
                table: "Picture");

            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "Picture",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PictureID",
                table: "PictureAccess",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoUserId",
                table: "PictureAccess",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "Picture",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "Picture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PictureAccess_PictureID",
                table: "PictureAccess",
                column: "PictureID");

            migrationBuilder.CreateIndex(
                name: "IX_PictureAccess_UserInfoUserId",
                table: "PictureAccess",
                column: "UserInfoUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PictureAccess_Picture_PictureID",
                table: "PictureAccess",
                column: "PictureID",
                principalTable: "Picture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PictureAccess_UserInfo_UserInfoUserId",
                table: "PictureAccess",
                column: "UserInfoUserId",
                principalTable: "UserInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
