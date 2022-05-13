using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseworkUI.Migrations
{
    public partial class Hide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Hide",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hide",
                table: "Users");
        }
    }
}
