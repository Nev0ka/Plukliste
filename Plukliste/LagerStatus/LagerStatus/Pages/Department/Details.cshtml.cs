﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LagerStatus.Pages.Department
{
    public class DetailsModel : PageModel
    {
        private readonly LagerStatus.Data.InventoryContext _context;

        public DetailsModel(LagerStatus.Data.InventoryContext context)
        {
            _context = context;
        }

        public Models.Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            else
            {
                Department = department;
            }
            return Page();
        }
    }
}
