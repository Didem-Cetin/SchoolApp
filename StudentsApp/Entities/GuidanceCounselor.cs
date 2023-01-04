using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsApp.Entities
{
    [Table("GuidanceCounselors")]
    public class GuidanceCounselor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<Student> Student { get; set; }

    }

}
