using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL.Entities;
using System.Threading.Tasks;

namespace mijnZorgRooster.Views
{
    public class DetailsModel : PageModel
    {
        private readonly mijnZorgRooster.DAL.ZorginstellingDbContext _context;

        public DetailsModel(mijnZorgRooster.DAL.ZorginstellingDbContext context)
        {
            _context = context;
        }

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
    }
}
