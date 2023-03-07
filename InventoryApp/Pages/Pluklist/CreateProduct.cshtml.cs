using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryApp.Pages.Pluklist
{
    public class CreateProductModel : ProductSelectlist
    {
        private readonly InventoryAppContext _context;
        internal static SelectList SelectedProducts { get; set; }

        public CreateProductModel(InventoryAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Items Items { get; set; }

        public IActionResult OnGet()
        {
            Items = new Items();
            Items.ProductID = "gg";
            Items.ProductName = "pp";
            ViewData["PluklistContentID"] = new SelectList(_context.PluklistContent, "ID", "ID");
            PopulateProductsDropdownList(_context);
            SelectedProducts = ProductSL;
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //foreach (var Model in ModelState.Values)
            //{
            //    foreach (var Error in Model.Errors)
            //    {
            //        var e = Error.ErrorMessage;
            //    }
            //}
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var item in SelectedProducts)
            {
                if(Items.ProductName == item.Value)
                {
                    Items.ProductName = item.Text;
                    Items.ProductID = item.Value;
                    break;
                }
            }

            _context.Items.Add(Items);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
