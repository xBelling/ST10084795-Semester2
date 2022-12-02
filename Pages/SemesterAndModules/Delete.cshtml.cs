using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POE_ST10084795.Data;
using POE_ST10084795.Models;

namespace POE_ST10084795.Pages.SemesterAndModules
{
    public class DeleteModel : PageModel
    {
        private readonly POE_ST10084795.Data.ApplicationDbContext _context;

        public DeleteModel(POE_ST10084795.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SemesterAndModule SemesterAndModule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SemesterAndModule == null)
            {
                return NotFound();
            }

            var semesterandmodule = await _context.SemesterAndModule.FirstOrDefaultAsync(m => m.ID == id);

            if (semesterandmodule == null)
            {
                return NotFound();
            }
            else 
            {
                SemesterAndModule = semesterandmodule;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SemesterAndModule == null)
            {
                return NotFound();
            }
            var semesterandmodule = await _context.SemesterAndModule.FindAsync(id);

            if (semesterandmodule != null)
            {
                SemesterAndModule = semesterandmodule;
                _context.SemesterAndModule.Remove(SemesterAndModule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
