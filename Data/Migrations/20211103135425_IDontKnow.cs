using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class IDontKnow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Picture",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_userId",
                table: "Picture",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_AspNetUsers_userId",
                table: "Picture",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_AspNetUsers_userId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_userId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Picture");
        }
    }
}
