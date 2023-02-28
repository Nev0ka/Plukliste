using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Pluklist
{
    public class EditModel : PageModel
    {
        private readonly InventoryAppContext _context;

        public EditModel(InventoryAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InventoryContent InventoryContent { get; set; } = default!;

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
            InventoryContent = inventorycontent;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InventoryContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryContentExists(InventoryContent.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InventoryContentExists(int id)
        {
            return _context.InventoryContent.Any(e => e.ID == id);
        }
    }
}
