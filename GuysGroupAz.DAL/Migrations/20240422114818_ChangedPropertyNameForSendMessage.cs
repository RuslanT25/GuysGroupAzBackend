using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuysGroupAz.DAL.Migrations
{
    public partial class ChangedPropertyNameForSendMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "SendMessages",
                newName: "Message");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "SendMessages",
                newName: "Note");
        }
    }
}
