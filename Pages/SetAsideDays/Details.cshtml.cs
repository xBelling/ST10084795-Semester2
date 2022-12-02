using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POE_ST10084795.Data;
using POE_ST10084795.Models;

namespace POE_ST10084795.Pages.SetAsideDays
{
    public class DetailsModel : PageModel
    {
        private readonly POE_ST10084795.Data.ApplicationDbContext _context;

        public DetailsModel(POE_ST10084795.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public SetAsideDay SetAsideDay { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SetAsideDay == null)
            {
                return NotFound();
            }

            var setasideday = await _context.SetAsideDay.FirstOrDefaultAsync(m => m.ID == id);
            if (setasideday == null)
            {
                return NotFound();
            }
            else 
            {
                SetAsideDay = setasideday;
            }
            return Page();
        }
    }
}
