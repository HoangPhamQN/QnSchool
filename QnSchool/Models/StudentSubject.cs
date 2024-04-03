using QnSchool.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace QnSchool.Models
{
    public class StudentSubject
    {

        [ForeignKey("Student")]
        public string StudentId { get; set; } = default!;
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public float averange { get; set; }
        public virtual User Student { get; set; } = default!;
        public virtual Subject Subject { get; set; } = default!;
    }
}
