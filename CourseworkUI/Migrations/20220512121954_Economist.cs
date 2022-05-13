using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseworkUI.Migrations
{
    public partial class Economist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Economists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Economists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Economists_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Economists");
        }
    }
}
