using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.Views
{
    public class IndexModel : PageModel
    {
        private readonly mijnZorgRooster.DAL.ZorginstellingDbContext _context;

        public IndexModel(mijnZorgRooster.DAL.ZorginstellingDbContext context)
        {
            _context = context;
        }

        public IList<Rol> Rol { get;set; }

        public async Task OnGetAsync()
        {
            Rol = await _context.Rollen.ToListAsync();
        }
    }
}
