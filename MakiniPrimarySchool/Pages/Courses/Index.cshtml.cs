using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MakiniPrimarySchool.Data;
using MakiniPrimarySchool.Models;

namespace MakiniPrimarySchool.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly MakiniPrimarySchool.Data.SchoolContext _context;

        public IndexModel(MakiniPrimarySchool.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get;set; }

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
            }
        }
    }
}
