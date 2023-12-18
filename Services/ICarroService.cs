using BonosCarrosWeb.Models;

namespace BonosCarrosWeb.Services;

public interface ICarroService
{
	IList<Carro> ObterTodosOsCarros();
	Carro Obter(int id);
	void Incluir(Carro carro);
	void Alterar(Carro carro);
	void Excluir(int id);
	IList<Marca> ObterTodasAsMarcas();
	IList<Designer> ObterTodosOsDesigners();


}
