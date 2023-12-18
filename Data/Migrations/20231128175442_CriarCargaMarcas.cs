using BonosCarrosWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonosCarrosWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriarCargaMarcas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new CarrosDbContext();
            context.Marca.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }
        
        private IList<Marca> ObterCargaInicial()
        {
            return new List<Marca>()
            {
                new Marca() {Nome = "Detomaso"},
                new Marca() {Nome= "Aston Martim"},
                new Marca() {Nome = "Ferrari"},
                new Marca() {Nome = "Paganni"},
                new Marca() {Nome = "McLaren"},
				new Marca() {Nome = "Brabus"}

			};
        }
    }
}
