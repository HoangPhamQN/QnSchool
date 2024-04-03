using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QnSchool.Data;
using QnSchool.Models;

namespace QnSchool.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly QnSchool.Data.QnSchoolContext _context;

        public IndexModel(QnSchool.Data.QnSchoolContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Subject = await _context.Subjects.ToListAsync();
        }
    }
}
