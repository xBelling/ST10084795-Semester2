using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using POE_ST10084795.Data;
using POE_ST10084795.Models;

namespace POE_ST10084795.Pages.SetAsideDays
{
    public class CreateModel : PageModel
    {
        private readonly POE_ST10084795.Data.ApplicationDbContext _context;

        public CreateModel(POE_ST10084795.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SetAsideDay SetAsideDay { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SetAsideDay.Add(SetAsideDay);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
