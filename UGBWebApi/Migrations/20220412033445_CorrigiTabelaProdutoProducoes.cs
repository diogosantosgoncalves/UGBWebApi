using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UGBWebApi.Migrations
{
    public partial class CorrigiTabelaProdutoProducoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoProducoes_Produtos_ProdutoId",
                table: "ProdutoProducoes");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoProducoes_ProdutoId",
                table: "ProdutoProducoes");

            migrationBuilder.DropColumn(
                name: "Ide",
                table: "ProdutoProducoes");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ProdutoProducoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Ide",
                table: "ProdutoProducoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "ProdutoProducoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoProducoes_ProdutoId",
                table: "ProdutoProducoes",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoProducoes_Produtos_ProdutoId",
                table: "ProdutoProducoes",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
