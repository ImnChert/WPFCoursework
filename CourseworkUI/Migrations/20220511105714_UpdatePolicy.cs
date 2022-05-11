using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseworkUI.Migrations
{
    public partial class UpdatePolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostOfTheInsuranceContract",
                table: "Polices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InsuranceAmount",
                table: "Polices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostOfTheInsuranceContract",
                table: "Polices");

            migrationBuilder.DropColumn(
                name: "InsuranceAmount",
                table: "Polices");
        }
    }
}
