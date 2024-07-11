using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GanaderiaLasDelicias.Migrations
{
    public partial class AddInsemination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insemination",
                columns: table => new
                {
                    InseminationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CowId = table.Column<int>(type: "int", nullable: false),
                    BullId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insemination", x => x.InseminationId);
                    table.ForeignKey(
                        name: "FK_Insemination_BullId",
                        column: x => x.BullId,
                        principalTable: "Bulls",
                        principalColumn: "BullId");
                    table.ForeignKey(
                        name: "FK_Insemination_CowId",
                        column: x => x.CowId,
                        principalTable: "Herd",
                        principalColumn: "CowId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insemination_BullId",
                table: "Insemination",
                column: "BullId");

            migrationBuilder.CreateIndex(
                name: "IX_Insemination_CowId",
                table: "Insemination",
                column: "CowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insemination");
        }
    }
}
