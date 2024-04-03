using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QnSchool.Data;
using QnSchool.Models;

namespace QnSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectsController : ControllerBase
    {
        private readonly QnSchoolContext _context;

        public StudentSubjectsController(QnSchoolContext context)
        {
            _context = context;
        }

        // GET: api/StudentSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSubject>>> GetStudentSubjects()
        {
            return await _context.StudentSubjects.ToListAsync();
        }

        // GET: api/StudentSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSubject>> GetStudentSubject(string id)
        {
            var studentSubject = await _context.StudentSubjects.FindAsync(id);

            if (studentSubject == null)
            {
                return NotFound();
            }

            return studentSubject;
        }

        // PUT: api/StudentSubjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutStudentSubject(UpdateAverangeDto studentSubject)
        {
            var _studentSubject = await _context.StudentSubjects.FirstOrDefaultAsync(ss => ss.StudentId == studentSubject.StudentId && ss.SubjectId == studentSubject.SubjectId);
            if (_studentSubject == null)
            {
                return NotFound();
            }
            _studentSubject.averange = studentSubject.Averange;
            _context.Entry(_studentSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentSubjectExists(_studentSubject.StudentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_studentSubject);
        }

        // POST: api/StudentSubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentSubject>> PostStudentSubject(CreateStudentSubjectDto studentSubject)
        {
            var _studentSubject = new StudentSubject
            {
                StudentId = studentSubject.StudentId,
                SubjectId = studentSubject.SubjectId,
            };
            _context.StudentSubjects.Add(_studentSubject);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentSubjectExists(_studentSubject.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentSubject", new { id = _studentSubject.StudentId }, _studentSubject);
        }

        // DELETE: api/StudentSubjects/5
        [HttpDelete]
        public async Task<IActionResult> DeleteStudentSubject(DeleteDto studentSubject)
        {
            var _studentSubject = await _context.StudentSubjects.FirstOrDefaultAsync(ss => ss.StudentId == studentSubject.StudentId && ss.SubjectId == studentSubject.SubjectId);
            if (_studentSubject == null)
            {
                return NotFound();
            }
            _context.StudentSubjects.Remove(_studentSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentSubjectExists(string id)
        {
            return _context.StudentSubjects.Any(e => e.StudentId == id);
        }
        public class CreateStudentSubjectDto
        {
            public string StudentId { get; set; }
            public int SubjectId { get; set; }
        }
        public class UpdateAverangeDto : CreateStudentSubjectDto
        {
            [Range(0, 10)]
            public float Averange { get; set; }
        }
        public class DeleteDto : CreateStudentSubjectDto
        {

        }
    }
}
