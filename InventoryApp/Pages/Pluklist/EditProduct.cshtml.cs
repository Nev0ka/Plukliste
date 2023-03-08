using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Pluklist
{
    public class EditProductModel : ProductSelectlist
    {
        private readonly InventoryAppContext _context;
        internal static SelectList SelectedProducts { get; set; }

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
            ViewData["PluklistContentID"] = new SelectList(_context.PluklistContent, "ID", "ID");
            PopulateProductsDropdownList(_context);
            SelectedProducts = ProductSL;
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

            foreach (var item in SelectedProducts)
            {
                if (Items.ProductName == item.Value)
                {
                    Items.ProductName = item.Text;
                    Items.ProductID = item.Value;
                    break;
                }
            }

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
            return RedirectToPage("./Index");
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.ID == id);
        }
    }
}
