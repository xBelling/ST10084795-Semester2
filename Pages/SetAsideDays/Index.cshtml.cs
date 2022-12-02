using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POE_ST10084795.Data;
using POE_ST10084795.Models;
using POE_ST10084795_ClassLibrary;

namespace POE_ST10084795.Pages.SetAsideDays
{
    public class IndexModel : PageModel
    {
        private readonly POE_ST10084795.Data.ApplicationDbContext _context;

        public IndexModel(POE_ST10084795.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SetAsideDay> SetAsideDay { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SetAsideDay != null)
            {
                SetAsideDay = await _context.SetAsideDay.ToListAsync();
            }

            DayAside dayAside = new DayAside();
            dayAside.GetSetAsideDay();
        }
    }
}
