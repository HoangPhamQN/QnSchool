using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QnSchool.Models
{
    public class Room
    {
        public int ID { get; set; }
        [DisplayName("Phòng học")]
        [Required]
        public required string Name { get; set; }
    }
}
