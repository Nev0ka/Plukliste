using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Pages.Pluklist
{
    public class IndexModel : PageModel
    {
        private readonly InventoryAppContext _context;

        public IndexModel(InventoryAppContext context)
        {
            _context = context;
        }

        public PluklistData pluklistData { get; set; }
        public int PluklistId { get; set; }
        public int ItemId { get; set; }

        public IList<PluklistContent> PluklistContent { get; set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            pluklistData = new PluklistData();
            pluklistData.Pluklists = await _context.PluklistContent
            .Include(i => i.Items)
            .ToListAsync();
            PluklistContent = (IList<PluklistContent>)pluklistData.Pluklists;

            if (id != null)
            {
                PluklistId = id.Value;
                PluklistContent instructor = pluklistData.Pluklists.Where(i => i.ID == id.Value).Single();
                pluklistData.Items = instructor.Items;
            }
        }

        //public async Task OnGetAsync()
        //{
        //    if (_context.PluklistContent != null)
        //    {
        //        PluklistContent = await _context.PluklistContent.ToListAsync();
        //    }
        //}
    }
}
