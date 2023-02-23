using LagerStatus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LagerStatus.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly LagerStatus.Data.InventoryContext _context;

        public DetailsModel(LagerStatus.Data.InventoryContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            Course = await _context.Courses
            .AsNoTracking()
            .Include(c => c.Department)
            .FirstOrDefaultAsync(m => m.CourseID == id);

            var course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = course;
            }
            return Page();
        }
    }
}
