using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Pages.Pluklist
{
    public class CreateProductModel : ProductSelectlist
    {
        private readonly InventoryAppContext _context;

        public CreateProductModel(InventoryAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateProductsDropdownList(_context);
            return Page();
        }

        [BindProperty]
        public Items Items { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Items.Add(Items);
            await _context.SaveChangesAsync();

            PopulateProductsDropdownList(_context);
            return RedirectToPage("./Index");
        }
    }
}
