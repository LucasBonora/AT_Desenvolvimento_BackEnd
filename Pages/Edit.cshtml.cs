using BonosCarrosWeb.Models;
using BonosCarrosWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BonosCarrosWeb.Pages
{
	[Authorize]
	public class EditModel : PageModel
    {
		private ICarroService _service;
		public SelectList MarcaOptionItems { get; set; }
		public SelectList DesignerOptionItems { get; set; }

		public EditModel(ICarroService carroService)
		{
			_service = carroService;
		}
		[BindProperty]
		public Carro Carro { get; set; }
		[BindProperty]
		public IList<int> DesignerIds { get; set; }
		public void OnGet(int id)
		{
			Carro = _service.Obter(id);
			DesignerIds = Carro.ListaDesigners.Select(item => item.DesignerId).ToList();
			MarcaOptionItems = new SelectList(_service.ObterTodasAsMarcas(),
				nameof(Marca.MarcaId),
				nameof(Marca.Nome));
			DesignerOptionItems = new SelectList(_service.ObterTodosOsDesigners(),
				nameof(Designer.DesignerId),
				nameof(Designer.Nome));

		}
		public IActionResult OnPost()
		{
			Carro.ListaDesigners = _service.ObterTodosOsDesigners()
												.Where(item => DesignerIds.Contains(item.DesignerId))
												.ToList();

			if (!ModelState.IsValid)
			{
				return Page();
			}
			_service.Alterar(Carro);

			return RedirectToPage("/Index");
		}
		public IActionResult OnPostDelete()
		{
			_service.Excluir(Carro.CarroId);
			return RedirectToPage("/Index");
		}
	}
}
