using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QnSchool.Models;

namespace QnSchool.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    [DisplayName("Địa chỉ")]
    public string Address { get; set; } = default!;
    [Required]
    [ForeignKey("Room")]
    public int RoomId { get; set; }
    [DisplayName("Lớp")]
    public Room Room { get; set; } = default!;
    public ICollection<StudentSubject> StudentSubjects { get; set; } = default!;
    public ICollection<TeacherSubject> TeacherSubjects { get; set; } = default!;
}

