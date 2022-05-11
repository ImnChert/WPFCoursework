using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseworkUI.Migrations
{
    public partial class Policy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Polices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    InsuranceAgentId = table.Column<int>(type: "int", nullable: false),
                    TypeOfInsuranceId = table.Column<int>(type: "int", nullable: false),
                    DateOfConclusion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polices_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polices_InsuranceAgents_InsuranceAgentId",
                        column: x => x.InsuranceAgentId,
                        principalTable: "InsuranceAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polices_TypesOfInsurances_TypeOfInsuranceId",
                        column: x => x.TypeOfInsuranceId,
                        principalTable: "TypesOfInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polices_ClientId",
                table: "Polices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Polices_InsuranceAgentId",
                table: "Polices",
                column: "InsuranceAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Polices_TypeOfInsuranceId",
                table: "Polices",
                column: "TypeOfInsuranceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polices");
        }
    }
}
