using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PixCollab.Data.Migrations
{
    public partial class newTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PictureMetadata",
                columns: table => new
                {
                    PictureId = table.Column<string>(nullable: false),
                    Geolocation = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureMetadata", x => x.PictureId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    UserInfoUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Picture_UserInfo_UserInfoUserId",
                        column: x => x.UserInfoUserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PictureAccess",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    PhotoId = table.Column<int>(nullable: false),
                    PictureID = table.Column<int>(nullable: true),
                    UserInfoUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureAccess", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_PictureAccess_Picture_PictureID",
                        column: x => x.PictureID,
                        principalTable: "Picture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureAccess_UserInfo_UserInfoUserId",
                        column: x => x.UserInfoUserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Picture_UserInfoUserId",
                table: "Picture",
                column: "UserInfoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureAccess_PictureID",
                table: "PictureAccess",
                column: "PictureID");

            migrationBuilder.CreateIndex(
                name: "IX_PictureAccess_UserInfoUserId",
                table: "PictureAccess",
                column: "UserInfoUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PictureAccess");

            migrationBuilder.DropTable(
                name: "PictureMetadata");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
