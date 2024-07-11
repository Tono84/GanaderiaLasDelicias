using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GanaderiaLasDelicias.Migrations
{
    public partial class AddInseminationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Insemination",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Insemination");
        }
    }
}
