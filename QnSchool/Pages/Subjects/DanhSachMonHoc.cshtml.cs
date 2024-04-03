using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using QnSchool.Areas.Identity.Data;
using QnSchool.Models;

namespace QnSchool.Pages.Subjects
{
    public class DanhSachMonHocModel : PageModel
    {
        private readonly QnSchool.Data.QnSchoolContext _context;
        private readonly UserManager<User> _userManager;

        public DanhSachMonHocModel(QnSchool.Data.QnSchoolContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<Subject> Subject { get; set; } = default!;
        [TempData]
        public string StatusMessage { get; set; }
        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user!=null)
            {
                if (User.IsInRole("HS"))
                {
                    Subject = await _context.Subjects
                    .Include(s => s.StudentSubjects)
                    .Where(s => s.StudentSubjects.Any(ss => ss.StudentId.ToString() == user.Id))
                    .ToListAsync();
                }
                if (User.IsInRole("GVCN"))
                {
                    Subject = await _context.Subjects
                    .Include(s => s.TeacherSubjects)
                    .Where(s => s.TeacherSubjects.Any(ss => ss.TeacherId.ToString() == user.Id))
                    .ToListAsync();
                    Console.WriteLine(Subject.Count);
                }
            }
            ViewData["SubjectList"] = new SelectList(_context.Subjects, "Id", "Name");
        }
    }
}
