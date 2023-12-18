using BonosCarrosWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonosCarrosWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriarCargaDesigners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new CarrosDbContext();
            context.Designer.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }

        private IList<Designer> ObterCargaInicial()
        {
            return new List<Designer>()
            {
                new Designer() {Nome = "Enzo"},
                new Designer() {Nome = "Oracio"},
                new Designer() {Nome = "Bruce" },
                new Designer() {Nome = "Alejandro" },
            };
        }


    }
}
