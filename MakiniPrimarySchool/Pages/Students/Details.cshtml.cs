﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MakiniPrimarySchool.Data;
using MakiniPrimarySchool.Models;

namespace MakiniPrimarySchool.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly MakiniPrimarySchool.Data.SchoolContext _context;

        public DetailsModel(MakiniPrimarySchool.Data.SchoolContext context)
        {
            _context = context;
        }

      public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            //var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);

            Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null) //changed student to Student
            {
                return NotFound();
            }
            //else 
            //{
            //    Student = student;
            //}
            return Page();
        }
    }
}
