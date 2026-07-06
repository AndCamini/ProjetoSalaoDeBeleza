using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSalaoDeBeleza.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Paises",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Paises",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "Paises",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Estados",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Estados",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "Estados",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Cidades",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Cidades",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "Cidades",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "Cidades");
        }
    }
}
