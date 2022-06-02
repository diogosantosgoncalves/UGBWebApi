using Microsoft.EntityFrameworkCore.Migrations;

namespace UGBWebApi.Migrations
{
    public partial class IncluidoCamposProducao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "Producoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSetor",
                table: "Producoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTurno",
                table: "Producoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "Producoes");

            migrationBuilder.DropColumn(
                name: "IdSetor",
                table: "Producoes");

            migrationBuilder.DropColumn(
                name: "IdTurno",
                table: "Producoes");
        }
    }
}
