using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonosCarrosWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoCarroMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Carro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carro_MarcaId",
                table: "Carro",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carro_Marca_MarcaId",
                table: "Carro",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carro_Marca_MarcaId",
                table: "Carro");

            migrationBuilder.DropIndex(
                name: "IX_Carro_MarcaId",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Carro");
        }
    }
}
