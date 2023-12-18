using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BonosCarrosWeb.Data;
using BonosCarrosWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace BonosCarrosWeb.Pages.Marcas
{
    public class IndexModel : PageModel

    {
		

		private readonly BonosCarrosWeb.Data.CarrosDbContext _context;

        public IndexModel(BonosCarrosWeb.Data.CarrosDbContext context)
        {
            _context = context;
        }

        public IList<Marca> Marca { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Marca != null)
            {
                Marca = await _context.Marca.ToListAsync();
            }
        }
    }
}
