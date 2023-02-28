using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Pluklist
{
    public class DetailsModel : PageModel
    {
        private readonly InventoryAppContext _context;

        public DetailsModel(InventoryAppContext context)
        {
            _context = context;
        }

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
    }
}
