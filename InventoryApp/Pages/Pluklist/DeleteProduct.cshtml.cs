using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Pluklist
{
    public class DeleteProductModel : PageModel
    {
        private readonly InventoryAppContext _context;

        public DeleteProductModel(InventoryAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Items Items { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var items = await _context.Items.FirstOrDefaultAsync(m => m.ID == id);

            if (items == null)
            {
                return NotFound();
            }
            else
            {
                Items = items;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }
            var items = await _context.Items.FindAsync(id);

            if (items != null)
            {
                Items = items;
                _context.Items.Remove(Items);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
