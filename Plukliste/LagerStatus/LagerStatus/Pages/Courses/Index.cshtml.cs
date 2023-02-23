using LagerStatus.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LagerStatus.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly LagerStatus.Data.InventoryContext _context;

        public IndexModel(LagerStatus.Data.InventoryContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get; set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
