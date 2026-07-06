using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSalaoDeBeleza.Migrations
{
    /// <inheritdoc />
    public partial class AjustesProfessor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntreParcelas",
                table: "CondicoesPagamento");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Veiculos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Veiculos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "Veiculos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Transportadores",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Transportadores",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "Transportadores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Produtos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Produtos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "Produtos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodCondicaoPagamento",
                table: "Pessoas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Pessoas",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PessoaJuridica",
                table: "Pessoas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodCondicaoPagamento",
                table: "Fornecedores",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Fornecedores",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Fornecedores",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PessoaJuridica",
                table: "Fornecedores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "Fornecedores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "FormasPagamento",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "FormasPagamento",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "FormasPagamento",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "CondicoesPagamento",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "CondicoesPagamento",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "CondicoesPagamento",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DDD",
                table: "Cidades",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Categorias",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Categorias",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "Categorias",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CodCondicaoPagamento",
                table: "Pessoas",
                column: "CodCondicaoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_CodCondicaoPagamento",
                table: "Fornecedores",
                column: "CodCondicaoPagamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_CondicoesPagamento_CodCondicaoPagamento",
                table: "Fornecedores",
                column: "CodCondicaoPagamento",
                principalTable: "CondicoesPagamento",
                principalColumn: "CodCondicao",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_CondicoesPagamento_CodCondicaoPagamento",
                table: "Pessoas",
                column: "CodCondicaoPagamento",
                principalTable: "CondicoesPagamento",
                principalColumn: "CodCondicao",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_CondicoesPagamento_CodCondicaoPagamento",
                table: "Fornecedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_CondicoesPagamento_CodCondicaoPagamento",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_CodCondicaoPagamento",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_CodCondicaoPagamento",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Transportadores");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Transportadores");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "Transportadores");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CodCondicaoPagamento",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "PessoaJuridica",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CodCondicaoPagamento",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "PessoaJuridica",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "FormasPagamento");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "FormasPagamento");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "FormasPagamento");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "CondicoesPagamento");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "CondicoesPagamento");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "CondicoesPagamento");

            migrationBuilder.DropColumn(
                name: "DDD",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "Categorias");

            migrationBuilder.AddColumn<int>(
                name: "EntreParcelas",
                table: "CondicoesPagamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
