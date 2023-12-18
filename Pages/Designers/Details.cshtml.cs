using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BonosCarrosWeb.Data;
using BonosCarrosWeb.Models;

namespace BonosCarrosWeb.Pages.Designers
{
    public class DetailsModel : PageModel
    {
        private readonly BonosCarrosWeb.Data.CarrosDbContext _context;

        public DetailsModel(BonosCarrosWeb.Data.CarrosDbContext context)
        {
            _context = context;
        }

      public Designer Designer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Designer == null)
            {
                return NotFound();
            }

            var designer = await _context.Designer.FirstOrDefaultAsync(m => m.DesignerId == id);
            if (designer == null)
            {
                return NotFound();
            }
            else 
            {
                Designer = designer;
            }
            return Page();
        }
    }
}
