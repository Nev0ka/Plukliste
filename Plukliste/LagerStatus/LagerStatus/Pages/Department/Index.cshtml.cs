using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LagerStatus.Pages.Department
{
    public class IndexModel : PageModel
    {
        private readonly LagerStatus.Data.InventoryContext _context;

        public IndexModel(LagerStatus.Data.InventoryContext context)
        {
            _context = context;
        }

        public IList<Models.Department> Department { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departments != null)
            {
                Department = await _context.Departments
                .Include(d => d.Administrator).ToListAsync();
            }
        }
    }
}
