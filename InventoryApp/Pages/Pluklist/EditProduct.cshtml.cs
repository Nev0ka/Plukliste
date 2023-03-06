using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Pluklist
{
    public class EditProductModel : ProductSelectlist
    {
        private readonly InventoryAppContext _context;

        public EditProductModel(InventoryAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Items Items { get; set; } = default!;

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
            Items = items;
            PopulateProductsDropdownList(_context);
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

            _context.Attach(Items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemsExists(Items.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            PopulateProductsDropdownList(_context);
            return RedirectToPage("./Index");
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.ID == id);
        }
    }
}
