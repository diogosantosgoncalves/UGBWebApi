using Microsoft.EntityFrameworkCore.Migrations;

namespace UGBWebApi.Migrations
{
    public partial class RemoverCampoSetor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasProducao",
                table: "Setores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HorasProducao",
                table: "Setores",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
