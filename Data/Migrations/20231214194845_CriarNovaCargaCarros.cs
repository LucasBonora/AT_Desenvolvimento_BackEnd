using BonosCarrosWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonosCarrosWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriarNovaCargaCarros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var context = new CarrosDbContext();
			context.Carro.AddRange(ObterCargaInicial());
			context.SaveChanges();
		}

		private IList<Carro> ObterCargaInicial()
		{
			return new List<Carro>()
			{
				new Carro()
			{
				Modelo = "P72",
				Descricao = "Elegância pura e desempenho excepcional em um design icônico.",
				ImgUri = "/images/DeTomasoP72_Azul_Escuro.jpg",
				Preco = 1300000,
				Disponibilidade = false,
				DataLancamento = DateTime.Now,
				Cep = "01001000",
				MarcaId = 1,
			},
			new Carro()
			{
				Modelo = "LaFerrari",
				Descricao = "O auge da engenharia automotiva, velocidade e elegância em perfeita harmonia.",
				ImgUri = "/images/La_Ferrari.jpg",
				Preco = 4000000,
				Disponibilidade = true,
				DataLancamento = DateTime.Now,
				Cep = "01001000",
				MarcaId = 3,
			},
			new Carro()
			{
				Modelo = "Utopia",
				Descricao = "O futuro do luxo automotivo, onde arte, tecnologia e velocidade se encontram.",
				ImgUri = "/images/Pagani_Utopia.jpg",
				Preco = 2170000,
				Disponibilidade = false,
				DataLancamento = DateTime.Now,
				Cep = "01001000",
				MarcaId = 4,
			},
			new Carro()
			{
				Modelo = "Valkyre",
				Descricao = " Supercarro exuberante, velocidade transcendental, desempenho sem igual.",
				ImgUri = "/images/Aston_Martin_Valkyre.jpg",
				Preco = 3200000,
				Disponibilidade = true,
				DataLancamento = DateTime.Now,
				Cep = "01001000",
				MarcaId = 2,
			},

			};
		}

	}
}
