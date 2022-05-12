using Microsoft.EntityFrameworkCore.Migrations;

namespace UGBWebApi.Migrations
{
    public partial class DeletadoQtdeTurno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qtde",
                table: "Turnos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Qtde",
                table: "Turnos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
