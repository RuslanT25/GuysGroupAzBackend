using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuysGroupAz.DAL.Migrations
{
    public partial class OtherInfoIdCanBeNullInOtherInfoDescriptionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherInfoDescriptions_OtherInfos_OtherInfoId",
                table: "OtherInfoDescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "OtherInfoId",
                table: "OtherInfoDescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherInfoDescriptions_OtherInfos_OtherInfoId",
                table: "OtherInfoDescriptions",
                column: "OtherInfoId",
                principalTable: "OtherInfos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherInfoDescriptions_OtherInfos_OtherInfoId",
                table: "OtherInfoDescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "OtherInfoId",
                table: "OtherInfoDescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherInfoDescriptions_OtherInfos_OtherInfoId",
                table: "OtherInfoDescriptions",
                column: "OtherInfoId",
                principalTable: "OtherInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
