using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UGBWebApi.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Producoes",
                newName: "Data");

            migrationBuilder.AddColumn<bool>(
                name: "Administrador",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Administrador",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "IndiceDisponibilidade",
                table: "Producoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IndicePerfomance",
                table: "Producoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IndiceQualidade",
                table: "Producoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Resultado",
                table: "Producoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CodigoProducao",
                table: "Perdas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodigoProducao",
                table: "Paradas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraFinal",
                table: "Paradas",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraInicial",
                table: "Paradas",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Administrador",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Administrador",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IndiceDisponibilidade",
                table: "Producoes");

            migrationBuilder.DropColumn(
                name: "IndicePerfomance",
                table: "Producoes");

            migrationBuilder.DropColumn(
                name: "IndiceQualidade",
                table: "Producoes");

            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "Producoes");

            migrationBuilder.DropColumn(
                name: "CodigoProducao",
                table: "Perdas");

            migrationBuilder.DropColumn(
                name: "CodigoProducao",
                table: "Paradas");

            migrationBuilder.DropColumn(
                name: "HoraFinal",
                table: "Paradas");

            migrationBuilder.DropColumn(
                name: "HoraInicial",
                table: "Paradas");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Producoes",
                newName: "DataCriacao");
        }
    }
}
