namespace BonosCarrosWeb.Models
{
    public class Designer
    {
        public int DesignerId { get; set; }
        public string Nome { get; set; }
        public ICollection<Carro>? ListaCarros { get; set; }
    }
}
