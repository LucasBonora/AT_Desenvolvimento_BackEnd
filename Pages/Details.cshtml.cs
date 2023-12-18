using BonosCarrosWeb.Models;
using BonosCarrosWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonosCarrosWeb.Pages
{
	public class DetailsModel : PageModel
	{
		private ICarroService _service;

		public DetailsModel(ICarroService carroService)
		{
			_service = carroService;
		}

		public Carro Carro { get; private set; }
        public Marca Marca { get; set; }

        public IActionResult OnGet(int id)
		{
			Carro = _service.Obter(id);
			Marca = _service.ObterTodasAsMarcas().SingleOrDefault(item => item.MarcaId == Carro.MarcaId);

			if (Carro == null)
			{
				return NotFound();
			}

			return Page();
		}
	}
}
