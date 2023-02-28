using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryApp.Pages.Pluklist
{
    public class CreateModel : PageModel
    {
        private readonly InventoryAppContext _context;

        public CreateModel(InventoryAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InventoryContent InventoryContent { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InventoryContent.Add(InventoryContent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
