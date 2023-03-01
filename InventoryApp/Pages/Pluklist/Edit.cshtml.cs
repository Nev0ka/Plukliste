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
        public PluklistContent PluklistContent { get; set; } = default!;

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
            PluklistContent = pluklistcontent;
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

            _context.Attach(PluklistContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PluklistContentExists(PluklistContent.ID))
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

        private bool PluklistContentExists(int id)
        {
            return _context.PluklistContent.Any(e => e.ID == id);
        }
    }
}
