using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishApp.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCodigoToPez : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Pez",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pez_Codigo",
                table: "Pez",
                column: "Codigo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pez_Codigo",
                table: "Pez");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Pez");
        }
    }
}
