using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuysGroupAz.DAL.Migrations
{
    public partial class AddQuestionRelationWithServiceAndCourseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CourseId",
                table: "Questions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ServiceId",
                table: "Questions",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Courses_CourseId",
                table: "Questions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Services_ServiceId",
                table: "Questions",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Courses_CourseId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Services_ServiceId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CourseId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ServiceId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
