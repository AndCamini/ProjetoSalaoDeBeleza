using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSalaoDeBeleza.Migrations
{
    /// <inheritdoc />
    public partial class AjusteChavesEstrangeiras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_oEstadoCodEstado",
                table: "Cidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Paises_oPaisCodPais",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Estados_oPaisCodPais",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_oEstadoCodEstado",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "oPaisCodPais",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "oEstadoCodEstado",
                table: "Cidades");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_CodPais",
                table: "Estados",
                column: "CodPais");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_CodEstado",
                table: "Cidades",
                column: "CodEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_CodEstado",
                table: "Cidades",
                column: "CodEstado",
                principalTable: "Estados",
                principalColumn: "CodEstado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Paises_CodPais",
                table: "Estados",
                column: "CodPais",
                principalTable: "Paises",
                principalColumn: "CodPais",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_CodEstado",
                table: "Cidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Paises_CodPais",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Estados_CodPais",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_CodEstado",
                table: "Cidades");

            migrationBuilder.AddColumn<int>(
                name: "oPaisCodPais",
                table: "Estados",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "oEstadoCodEstado",
                table: "Cidades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estados_oPaisCodPais",
                table: "Estados",
                column: "oPaisCodPais");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_oEstadoCodEstado",
                table: "Cidades",
                column: "oEstadoCodEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_oEstadoCodEstado",
                table: "Cidades",
                column: "oEstadoCodEstado",
                principalTable: "Estados",
                principalColumn: "CodEstado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Paises_oPaisCodPais",
                table: "Estados",
                column: "oPaisCodPais",
                principalTable: "Paises",
                principalColumn: "CodPais",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
