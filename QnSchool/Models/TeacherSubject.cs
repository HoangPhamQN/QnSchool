using QnSchool.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace QnSchool.Models
{
    public class TeacherSubject
    {
        [ForeignKey("Teacher")]
        public string TeacherId { get; set; } = default!;
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual User Teacher { get; set; } = default!;
        public virtual Subject Subject { get; set; } = default!;
    }

}
