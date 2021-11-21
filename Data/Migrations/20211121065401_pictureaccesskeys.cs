using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class pictureaccesskeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_PictureAccess_PhotoId",
                table: "PictureAccess",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PictureAccess_Picture_PhotoId",
                table: "PictureAccess",
                column: "PhotoId",
                principalTable: "Picture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PictureAccess_UserInfo_UserId",
                table: "PictureAccess",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PictureAccess_Picture_PhotoId",
                table: "PictureAccess");

            migrationBuilder.DropForeignKey(
                name: "FK_PictureAccess_UserInfo_UserId",
                table: "PictureAccess");

            migrationBuilder.DropIndex(
                name: "IX_PictureAccess_PhotoId",
                table: "PictureAccess");
        }
    }
}
