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
    public class DeleteModel : PageModel
    {
        private readonly POE_ST10084795.Data.ApplicationDbContext _context;

        public DeleteModel(POE_ST10084795.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SetAsideDay == null)
            {
                return NotFound();
            }
            var setasideday = await _context.SetAsideDay.FindAsync(id);

            if (setasideday != null)
            {
                SetAsideDay = setasideday;
                _context.SetAsideDay.Remove(SetAsideDay);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
