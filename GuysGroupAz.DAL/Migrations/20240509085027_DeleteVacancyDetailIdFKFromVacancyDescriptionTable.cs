using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuysGroupAz.DAL.Migrations
{
    public partial class DeleteVacancyDetailIdFKFromVacancyDescriptionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacancyDescriptions_VacancyDetails_VacancyDetailId",
                table: "VacancyDescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "VacancyDetailId",
                table: "VacancyDescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyDescriptions_VacancyDetails_VacancyDetailId",
                table: "VacancyDescriptions",
                column: "VacancyDetailId",
                principalTable: "VacancyDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacancyDescriptions_VacancyDetails_VacancyDetailId",
                table: "VacancyDescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "VacancyDetailId",
                table: "VacancyDescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyDescriptions_VacancyDetails_VacancyDetailId",
                table: "VacancyDescriptions",
                column: "VacancyDetailId",
                principalTable: "VacancyDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
