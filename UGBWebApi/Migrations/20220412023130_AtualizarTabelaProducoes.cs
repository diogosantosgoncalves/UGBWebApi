using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UGBWebApi.Migrations
{
    public partial class AtualizarTabelaProducoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paradas_Producoes_ProducaoId",
                table: "Paradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Perdas_Producoes_ProducaoId",
                table: "Perdas");

            migrationBuilder.DropForeignKey(
                name: "FK_Producoes_Produtos_ProdutoId",
                table: "Producoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Producoes_Setores_SetorId",
                table: "Producoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Producoes_Turnos_TurnoId",
                table: "Producoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Producoes_Usuarios_UsuarioId",
                table: "Producoes");

            migrationBuilder.DropIndex(
                name: "IX_Producoes_ProdutoId",
                table: "Producoes");

            migrationBuilder.DropIndex(
                name: "IX_Producoes_SetorId",
                table: "Producoes");

            migrationBuilder.DropIndex(
                name: "IX_Producoes_TurnoId",
                table: "Producoes");

            migrationBuilder.DropIndex(
                name: "IX_Producoes_UsuarioId",
                table: "Producoes");

            migrationBuilder.DropIndex(
                name: "IX_Perdas_ProducaoId",
                table: "Perdas");

            migrationBuilder.DropIndex(
                name: "IX_Paradas_ProducaoId",
                table: "Paradas");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Producoes");

            migrationBuilder.DropColumn(
                name: "SetorId",
                table: "Producoes");

            migrationBuilder.DropColumn(
                name: "TurnoId",
                table: "Producoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Producoes");

            migrationBuilder.DropColumn(
                name: "ProducaoId",
                table: "Perdas");

            migrationBuilder.DropColumn(
                name: "ProducaoId",
                table: "Paradas");

            migrationBuilder.CreateTable(
                name: "ProdutoProducoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ide = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qtde = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdeEstimada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoProducoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoProducoes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoProducoes_ProdutoId",
                table: "ProdutoProducoes",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoProducoes");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Producoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SetorId",
                table: "Producoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TurnoId",
                table: "Producoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Producoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProducaoId",
                table: "Perdas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProducaoId",
                table: "Paradas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producoes_ProdutoId",
                table: "Producoes",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producoes_SetorId",
                table: "Producoes",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Producoes_TurnoId",
                table: "Producoes",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producoes_UsuarioId",
                table: "Producoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Perdas_ProducaoId",
                table: "Perdas",
                column: "ProducaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_ProducaoId",
                table: "Paradas",
                column: "ProducaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paradas_Producoes_ProducaoId",
                table: "Paradas",
                column: "ProducaoId",
                principalTable: "Producoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Perdas_Producoes_ProducaoId",
                table: "Perdas",
                column: "ProducaoId",
                principalTable: "Producoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producoes_Produtos_ProdutoId",
                table: "Producoes",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producoes_Setores_SetorId",
                table: "Producoes",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producoes_Turnos_TurnoId",
                table: "Producoes",
                column: "TurnoId",
                principalTable: "Turnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producoes_Usuarios_UsuarioId",
                table: "Producoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
