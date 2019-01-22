using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Views
{
    public class EditModel : PageModel
    {
        private readonly mijnZorgRooster.DAL.ZorginstellingDbContext _context;

        public EditModel(mijnZorgRooster.DAL.ZorginstellingDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rol Rol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rol = await _context.Rollen.FirstOrDefaultAsync(m => m.RolID == id);

            if (Rol == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(Rol.RolID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RolExists(int id)
        {
            return _context.Rollen.Any(e => e.RolID == id);
        }
    }
}
