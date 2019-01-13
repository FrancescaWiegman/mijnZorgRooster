using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Views
{
    public class CreateModel : PageModel
    {
        private readonly mijnZorgRooster.DAL.ZorginstellingDbContext _context;

        public CreateModel(mijnZorgRooster.DAL.ZorginstellingDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Rol Rol { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rollen.Add(Rol);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}