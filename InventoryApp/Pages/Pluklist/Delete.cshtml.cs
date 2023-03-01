using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Pluklist
{
    public class DeleteModel : PageModel
    {
        private readonly InventoryAppContext _context;

        public DeleteModel(InventoryAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PluklistContent PluklistContent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PluklistContent == null)
            {
                return NotFound();
            }

            var pluklistcontent = await _context.PluklistContent.FirstOrDefaultAsync(m => m.ID == id);

            if (pluklistcontent == null)
            {
                return NotFound();
            }
            else
            {
                PluklistContent = pluklistcontent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PluklistContent == null)
            {
                return NotFound();
            }
            var pluklistcontent = await _context.PluklistContent.FindAsync(id);

            if (pluklistcontent != null)
            {
                PluklistContent = pluklistcontent;
                _context.PluklistContent.Remove(PluklistContent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
