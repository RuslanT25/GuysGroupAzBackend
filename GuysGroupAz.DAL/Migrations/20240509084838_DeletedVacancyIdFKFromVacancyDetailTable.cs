using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuysGroupAz.DAL.Migrations
{
    public partial class DeletedVacancyIdFKFromVacancyDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacancyDetails_Vacancies_VacancyId",
                table: "VacancyDetails");

            migrationBuilder.AlterColumn<int>(
                name: "VacancyId",
                table: "VacancyDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyDetails_Vacancies_VacancyId",
                table: "VacancyDetails",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacancyDetails_Vacancies_VacancyId",
                table: "VacancyDetails");

            migrationBuilder.AlterColumn<int>(
                name: "VacancyId",
                table: "VacancyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyDetails_Vacancies_VacancyId",
                table: "VacancyDetails",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
