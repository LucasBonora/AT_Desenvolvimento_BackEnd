using BonosCarrosWeb.Data;
using BonosCarrosWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BonosCarrosWeb.Services.Data
{
	public class CarroService : ICarroService
	{
		private CarrosDbContext _context;
		public CarroService (CarrosDbContext carrosDbContext)
		{
			_context = carrosDbContext;
		}
		public void Alterar(Carro carro)
		{
			var carroEncontrado = Obter(carro.CarroId);
			carroEncontrado.Modelo = carro.Modelo;
			carroEncontrado.ImgUri = carro.ImgUri;
			carroEncontrado.Cep = carro.Cep;
			carroEncontrado.Descricao = carro.Descricao;
			carroEncontrado.Preco = carro.Preco;
			carroEncontrado.Disponibilidade = carro.Disponibilidade;
			carroEncontrado.DataLancamento = carro.DataLancamento;
			carroEncontrado.MarcaId = carro.MarcaId;
			carroEncontrado.ListaDesigners = carro.ListaDesigners;
				

			_context.SaveChanges();
		}

		public void Excluir(int id)
		{
			var carroEncontrado = Obter(id);
			_context.Carro.Remove(carroEncontrado);
			_context.SaveChanges();
		}

		public void Incluir(Carro carro)
		{
			_context.Carro.Add(carro);
			_context.SaveChanges(); 
		}

		public Carro Obter(int id)
		{
			return _context.Carro
				.Include(item => item.ListaDesigners)
				.SingleOrDefault(item => item.CarroId == id);
		}

		public IList<Marca> ObterTodasAsMarcas()
		{
			return _context.Marca.ToList();
		}

		public IList<Carro> ObterTodosOsCarros()
		{
			return _context.Carro.ToList();
		}

		public IList<Designer> ObterTodosOsDesigners()
		{
			return _context.Designer.ToList();
		}
	}
}
