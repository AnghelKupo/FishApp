using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishApp.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estanque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tipo = table.Column<double>(type: "float", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estanque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pez",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sexo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PeriodoReproduccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pez", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PezEstanque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPez = table.Column<int>(type: "int", nullable: false),
                    IdEstanque = table.Column<int>(type: "int", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotivoMovimento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PezEstanque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PezEstanque_Estanque_IdEstanque",
                        column: x => x.IdEstanque,
                        principalTable: "Estanque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PezEstanque_Pez_IdPez",
                        column: x => x.IdPez,
                        principalTable: "Pez",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PezEstanque_IdEstanque",
                table: "PezEstanque",
                column: "IdEstanque");

            migrationBuilder.CreateIndex(
                name: "IX_PezEstanque_IdPez",
                table: "PezEstanque",
                column: "IdPez");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PezEstanque");

            migrationBuilder.DropTable(
                name: "Estanque");

            migrationBuilder.DropTable(
                name: "Pez");
        }
    }
}
