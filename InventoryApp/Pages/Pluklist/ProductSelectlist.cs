using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Pluklist
{
    public class ProductSelectlist : PageModel
    {
        public SelectList ProductSL { get; set; }
        public SelectList TypeSL { get; set; }

        public ProductSelectlist()
        {
            string[] types = { "Fysisk", "PRINT" };
            TypeSL = new SelectList(types);
        }

        public void PopulateProductsDropdownList(InventoryAppContext _context, object selectedProduct = null)
        {
            var productsQuery = from d in _context.InventoryContent
                                orderby d.ProductName
                                select d;
            ProductSL = new SelectList(productsQuery.AsNoTracking(),
                nameof(InventoryContent.ProductId),
                nameof(InventoryContent.ProductName),
                selectedProduct);
        }
    }
}
