using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuysGroupAz.DAL.Migrations
{
    public partial class ServiceIdCanBeNullInQuestionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Services_ServiceId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Services_ServiceId",
                table: "Questions",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Services_ServiceId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Services_ServiceId",
                table: "Questions",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
