using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QnSchool.Areas.Identity.Data;
using QnSchool.Models;
using System.Reflection.Emit;

namespace QnSchool.Data;

public class QnSchoolContext : IdentityDbContext<User>
{
    public QnSchoolContext(DbContextOptions<QnSchoolContext> options)
        : base(options)
    {
    }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<StudentSubject> StudentSubjects { get; set; }
    public DbSet<TeacherSubject> TeacherSubjects { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<TeacherSubject>()
            .HasKey(ts => new { ts.TeacherId, ts.SubjectId });
        builder.Entity<StudentSubject>()
           .HasKey(ts => new { ts.StudentId, ts.SubjectId });
    }
}
