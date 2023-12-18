namespace BonosCarrosWeb.Models
{
	public class Marca
	{
        public int MarcaId { get; set; }
        public string Nome { get; set; }
        public ICollection<Carro>? ListaCarros { get; set; }
    }
}
