using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonosCarrosWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelaDesigners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designer",
                columns: table => new
                {
                    DesignerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designer", x => x.DesignerId);
                    table.ForeignKey(
                        name: "FK_Designer_Carro_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carro",
                        principalColumn: "CarroId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Designer_CarroId",
                table: "Designer",
                column: "CarroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Designer");
        }
    }
}
