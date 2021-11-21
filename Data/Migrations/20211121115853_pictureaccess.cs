using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class pictureaccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropPrimaryKey(
                name: "PK_PictureAccess",
                table: "PictureAccess");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PictureAccess");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PictureAccess",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "PictureAccess",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PictureAccess",
                table: "PictureAccess",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_PictureAccess_UserId",
                table: "PictureAccess",
                column: "UserId");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PictureAccess_UserInfo_UserId",
                table: "PictureAccess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PictureAccess",
                table: "PictureAccess");

            migrationBuilder.DropIndex(
                name: "IX_PictureAccess_UserId",
                table: "PictureAccess");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "PictureAccess");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PictureAccess",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "PictureAccess",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PictureAccess",
                table: "PictureAccess",
                column: "UserId");

           
        }
    }
}
