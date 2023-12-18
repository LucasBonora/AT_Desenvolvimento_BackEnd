using BonosCarrosWeb.Models;
using BonosCarrosWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonosCarrosWeb.Pages
{
    public class IndexModel : PageModel
    {
        private ICarroService _service;

        public IndexModel(ICarroService carroService)
        {
            _service = carroService;
        }

        public IList<Carro> ListaCarros { get; private set; }
        public Carro Carro { get; set; }
        public Marca Marca { get; set; }
        public void OnGet()
        {
            ListaCarros = _service.ObterTodosOsCarros();
		}
	}
}