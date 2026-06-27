using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishApp.API.Migrations
{
    /// <inheritdoc />
    public partial class AddEspecieYConfigReproduccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Crear tabla Especie primero para poder referenciarla
            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.Id);
                });

            // 2. Crear tabla ConfiguracionReproduccion
            migrationBuilder.CreateTable(
                name: "ConfiguracionReproduccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspecieId = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<bool>(type: "bit", nullable: false),
                    DiasCiclo = table.Column<int>(type: "int", nullable: false),
                    DuracionEtapa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionReproduccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracionReproduccion_Especie_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // 3. Insertar especie por defecto (Id=1) para que los registros existentes puedan referenciarla
            migrationBuilder.InsertData(
                table: "Especie",
                columns: new[] { "Descripcion" },
                values: new object[] { "Sin especificar" });

            // 4. Remover columna antigua
            migrationBuilder.DropColumn(
                name: "PeriodoReproduccion",
                table: "Pez");

            // 5. Agregar nueva columna FechaUltimaReproduccion
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaUltimaReproduccion",
                table: "Pez",
                type: "datetime2",
                nullable: true);

            // 6. Agregar columna EspecieId con default = 1 (especie por defecto)
            migrationBuilder.AddColumn<int>(
                name: "EspecieId",
                table: "Pez",
                type: "int",
                nullable: false,
                defaultValue: 1);

            // 7. Crear índices
            migrationBuilder.CreateIndex(
                name: "IX_Pez_EspecieId",
                table: "Pez",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionReproduccion_EspecieId_Sexo",
                table: "ConfiguracionReproduccion",
                columns: new[] { "EspecieId", "Sexo" },
                unique: true);

            // 8. Agregar FK de Pez → Especie
            migrationBuilder.AddForeignKey(
                name: "FK_Pez_Especie_EspecieId",
                table: "Pez",
                column: "EspecieId",
                principalTable: "Especie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pez_Especie_EspecieId",
                table: "Pez");

            migrationBuilder.DropTable(
                name: "ConfiguracionReproduccion");

            migrationBuilder.DropTable(
                name: "Especie");

            migrationBuilder.DropIndex(
                name: "IX_Pez_EspecieId",
                table: "Pez");

            migrationBuilder.DropColumn(
                name: "EspecieId",
                table: "Pez");

            migrationBuilder.DropColumn(
                name: "FechaUltimaReproduccion",
                table: "Pez");

            migrationBuilder.AddColumn<string>(
                name: "PeriodoReproduccion",
                table: "Pez",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
