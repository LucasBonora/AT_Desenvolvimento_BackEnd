using BonosCarrosWeb.Models;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BonosCarrosWeb.Services.Memory;

public class CarroService : ICarroService
{
    public IList<Carro> _carros;

    public CarroService() => CarregarListaInicial();

    public void CarregarListaInicial()
    {
        _carros = new List<Carro>()
        {
            new Carro()
            {
                CarroId = 1,
                Modelo = "P72",
                //Marca = "De Tomaso",
                Descricao = "Elegância pura e desempenho excepcional em um design icônico.",
                ImgUri = "/images/DeTomasoP72_Azul_Escuro.jpg",
                Preco = 1300000,
                Disponibilidade = false,
                DataLancamento = DateTime.Now,
            },
            new Carro()
            {
                CarroId = 2,
                Modelo = "LaFerrari",
                //Marca = "Ferrari",
                Descricao = "O auge da engenharia automotiva, velocidade e elegância em perfeita harmonia.",
                ImgUri = "/images/La_Ferrari.jpg",
                Preco = 4000000,
                Disponibilidade = true,
                DataLancamento = DateTime.Now,
            },
            new Carro()
            {
                CarroId = 3,
                Modelo = "Utopia",
                //Marca = "Pagani",
                Descricao = "O futuro do luxo automotivo, onde arte, tecnologia e velocidade se encontram.",
                ImgUri = "/images/Pagani_Utopia.jpg",
                Preco = 2170000,
                Disponibilidade = false,
                DataLancamento = DateTime.Now,
            },
            new Carro()
            {
                CarroId = 4,
                Modelo = "Valkyre",
                //Marca = "Aston Martin",
                Descricao = " Supercarro exuberante, velocidade transcendental, desempenho sem igual.",
                ImgUri = "/images/Aston_Martin_Valkyre.jpg",
                Preco = 3200000,
                Disponibilidade = true,
                DataLancamento = DateTime.Now,
            },
        };
    }

    public IList<Carro> ObterTodosOsCarros() => _carros;

    public Carro Obter(int id)
    {
        return ObterTodosOsCarros().SingleOrDefault(item => item.CarroId == id);
    }

    public void Incluir(Carro carro)
    {
        var proximoId = _carros.Max(item => item.CarroId) + 1;
        carro.CarroId = proximoId;
        _carros.Add(carro);
    }

    public void Alterar(Carro carro)
    {
        var carroEncontrado = Obter(carro.CarroId);
        carroEncontrado.Modelo = carro.Modelo;
        carroEncontrado.ImgUri = carro.ImgUri;
        carroEncontrado.Descricao = carro.Descricao;
        //carroEncontrado.Marca = carro.Marca;
        carroEncontrado.Preco = carro.Preco;
        carroEncontrado.Disponibilidade = carro.Disponibilidade;
        carroEncontrado.DataLancamento = carro.DataLancamento;

    }

    public void Excluir(int id)
    {
        var carroEncontrado = Obter(id);
        _carros.Remove(carroEncontrado);
    }

	public IList<Marca> ObterTodasAsMarcas()
	{
		throw new NotImplementedException();
	}

	public IList<Designer> ObterTodosOsDesigners()
	{
		throw new NotImplementedException();
	}
}
