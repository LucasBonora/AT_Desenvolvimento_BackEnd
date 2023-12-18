using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BonosCarrosWeb.Data;
using BonosCarrosWeb.Models;

namespace BonosCarrosWeb.Pages.Designers
{
    public class CreateModel : PageModel
    {
        private readonly BonosCarrosWeb.Data.CarrosDbContext _context;

        public CreateModel(BonosCarrosWeb.Data.CarrosDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Designer Designer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Designer == null || Designer == null)
            {
                return Page();
            }

            _context.Designer.Add(Designer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
