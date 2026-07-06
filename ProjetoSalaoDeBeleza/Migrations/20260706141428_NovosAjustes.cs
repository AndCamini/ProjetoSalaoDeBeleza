using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSalaoDeBeleza.Migrations
{
    /// <inheritdoc />
    public partial class NovosAjustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "TiposVeiculos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "TiposVeiculos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "TiposVeiculos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "MarcasVeiculos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "MarcasVeiculos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUltimaAlteracao",
                table: "MarcasVeiculos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "TiposVeiculos");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "TiposVeiculos");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "TiposVeiculos");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "MarcasVeiculos");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "MarcasVeiculos");

            migrationBuilder.DropColumn(
                name: "UsuarioUltimaAlteracao",
                table: "MarcasVeiculos");
        }
    }
}
