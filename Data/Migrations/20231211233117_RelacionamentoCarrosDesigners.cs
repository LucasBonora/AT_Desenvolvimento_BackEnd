using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonosCarrosWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoCarrosMarcas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designer_Carro_CarroId",
                table: "Designer");

            migrationBuilder.DropIndex(
                name: "IX_Designer_CarroId",
                table: "Designer");

            migrationBuilder.DropColumn(
                name: "CarroId",
                table: "Designer");

            migrationBuilder.CreateTable(
                name: "CarroDesigner",
                columns: table => new
                {
                    ListaCarrosCarroId = table.Column<int>(type: "int", nullable: false),
                    ListaDesignersDesignerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroDesigner", x => new { x.ListaCarrosCarroId, x.ListaDesignersDesignerId });
                    table.ForeignKey(
                        name: "FK_CarroDesigner_Carro_ListaCarrosCarroId",
                        column: x => x.ListaCarrosCarroId,
                        principalTable: "Carro",
                        principalColumn: "CarroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarroDesigner_Designer_ListaDesignersDesignerId",
                        column: x => x.ListaDesignersDesignerId,
                        principalTable: "Designer",
                        principalColumn: "DesignerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarroDesigner_ListaDesignersDesignerId",
                table: "CarroDesigner",
                column: "ListaDesignersDesignerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroDesigner");

            migrationBuilder.AddColumn<int>(
                name: "CarroId",
                table: "Designer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Designer_CarroId",
                table: "Designer",
                column: "CarroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Designer_Carro_CarroId",
                table: "Designer",
                column: "CarroId",
                principalTable: "Carro",
                principalColumn: "CarroId");
        }
    }
}
