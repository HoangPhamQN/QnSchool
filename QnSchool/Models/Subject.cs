using System.ComponentModel;

namespace QnSchool.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [DisplayName("Tên môn học")]
        public string Name { get; set; } = default!;
        public ICollection<StudentSubject> StudentSubjects { get; set; } = default!;
        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = default!;
    }
}
