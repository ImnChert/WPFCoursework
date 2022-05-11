using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseworkUI.Migrations
{
    public partial class UpfrateMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromType",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromType",
                table: "Messages");
        }
    }
}
