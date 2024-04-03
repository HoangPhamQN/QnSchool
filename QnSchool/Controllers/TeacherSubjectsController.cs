using System;
using System.Collections.Generic;
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
    public class TeacherSubjectsController : ControllerBase
    {
        private readonly QnSchoolContext _context;

        public TeacherSubjectsController(QnSchoolContext context)
        {
            _context = context;
        }

        // GET: api/TeacherSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherSubject>>> GetTeacherSubjects()
        {
            return await _context.TeacherSubjects.ToListAsync();
        }

        // GET: api/TeacherSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherSubject>> GetTeacherSubject(string id)
        {
            var teacherSubject = await _context.TeacherSubjects.FindAsync(id);

            if (teacherSubject == null)
            {
                return NotFound();
            }

            return teacherSubject;
        }

        // PUT: api/TeacherSubjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherSubject(string id, TeacherSubject teacherSubject)
        {
            if (id != teacherSubject.TeacherId)
            {
                return BadRequest();
            }

            _context.Entry(teacherSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherSubjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TeacherSubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherSubject>> PostTeacherSubject(CreateTeacherSubjectDto teacherSubject)
        {
            var _teacherSubject = new TeacherSubject
            {
                TeacherId = teacherSubject.TeacherId,
                SubjectId = teacherSubject.SubjectId
            };
            _context.TeacherSubjects.Add(_teacherSubject);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeacherSubjectExists(_teacherSubject.TeacherId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeacherSubject", new { id = _teacherSubject.TeacherId }, _teacherSubject);
        }

        // DELETE: api/TeacherSubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherSubject(string id)
        {
            var teacherSubject = await _context.TeacherSubjects.FindAsync(id);
            if (teacherSubject == null)
            {
                return NotFound();
            }

            _context.TeacherSubjects.Remove(teacherSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherSubjectExists(string id)
        {
            return _context.TeacherSubjects.Any(e => e.TeacherId == id);
        }
        public class CreateTeacherSubjectDto
        {
            public string TeacherId { get; set; }
            public int SubjectId { get; set; }
        }
    }
}
