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
        public InventoryContent InventoryContent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.InventoryContent == null)
            {
                return NotFound();
            }

            var inventorycontent = await _context.InventoryContent.FirstOrDefaultAsync(m => m.ID == id);

            if (inventorycontent == null)
            {
                return NotFound();
            }
            else
            {
                InventoryContent = inventorycontent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.InventoryContent == null)
            {
                return NotFound();
            }
            var inventorycontent = await _context.InventoryContent.FindAsync(id);

            if (inventorycontent != null)
            {
                InventoryContent = inventorycontent;
                _context.InventoryContent.Remove(InventoryContent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
