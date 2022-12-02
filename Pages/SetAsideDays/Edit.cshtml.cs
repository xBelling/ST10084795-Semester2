using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POE_ST10084795.Data;
using POE_ST10084795.Models;

namespace POE_ST10084795.Pages.SetAsideDays
{
    public class EditModel : PageModel
    {
        private readonly POE_ST10084795.Data.ApplicationDbContext _context;

        public EditModel(POE_ST10084795.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SetAsideDay SetAsideDay { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SetAsideDay == null)
            {
                return NotFound();
            }

            var setasideday =  await _context.SetAsideDay.FirstOrDefaultAsync(m => m.ID == id);
            if (setasideday == null)
            {
                return NotFound();
            }
            SetAsideDay = setasideday;
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

            _context.Attach(SetAsideDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetAsideDayExists(SetAsideDay.ID))
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

        private bool SetAsideDayExists(int id)
        {
          return _context.SetAsideDay.Any(e => e.ID == id);
        }
    }
}
