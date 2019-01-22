using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mijnZorgRooster.DAL.Entities;
using System.Threading.Tasks;

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