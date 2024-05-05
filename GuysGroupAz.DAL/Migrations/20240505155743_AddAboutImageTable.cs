using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuysGroupAz.DAL.Migrations
{
    public partial class AddAboutImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsImage_News_NewsId",
                table: "NewsImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsImage",
                table: "NewsImage");

            migrationBuilder.RenameTable(
                name: "NewsImage",
                newName: "NewsImages");

            migrationBuilder.RenameIndex(
                name: "IX_NewsImage_NewsId",
                table: "NewsImages",
                newName: "IX_NewsImages_NewsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsImages",
                table: "NewsImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AboutImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutImages_Abouts_AboutId",
                        column: x => x.AboutId,
                        principalTable: "Abouts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutImages_AboutId",
                table: "AboutImages",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsImages_News_NewsId",
                table: "NewsImages",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsImages_News_NewsId",
                table: "NewsImages");

            migrationBuilder.DropTable(
                name: "AboutImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsImages",
                table: "NewsImages");

            migrationBuilder.RenameTable(
                name: "NewsImages",
                newName: "NewsImage");

            migrationBuilder.RenameIndex(
                name: "IX_NewsImages_NewsId",
                table: "NewsImage",
                newName: "IX_NewsImage_NewsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsImage",
                table: "NewsImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsImage_News_NewsId",
                table: "NewsImage",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");
        }
    }
}
