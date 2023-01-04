using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsApp.Entities
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Fullname { get; set; }
        [Required]
        public int DepartmanId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int GuidanceCounselorId { get; set; }
        public Departman Departman{ get; set; }
        public Teacher Teacher { get; set; }
        public GuidanceCounselor GuidanceCounselor { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }

}
