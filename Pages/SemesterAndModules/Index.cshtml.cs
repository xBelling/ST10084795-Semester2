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
    public class IndexModel : PageModel
    {
        private readonly POE_ST10084795.Data.ApplicationDbContext _context;

        public IndexModel(POE_ST10084795.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SemesterAndModule> SemesterAndModule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SemesterAndModule != null)
            {
                SemesterAndModule = await _context.SemesterAndModule.ToListAsync();
            }
        }
    }
}
