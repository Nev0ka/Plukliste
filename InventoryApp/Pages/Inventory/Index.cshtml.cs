using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly InventoryAppContext _context;

        public IndexModel(InventoryAppContext context)
        {
            _context = context;
        }

        public IList<InventoryContent> InventoryContent { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.InventoryContent != null)
            {
                InventoryContent = await _context.InventoryContent.ToListAsync();
            }
        }
    }
}
