
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StudentsApp.Models
{
    public class PartialCreateModel
    {
        [Required(ErrorMessage ="Öğrencinin İsmini Girmelisiniz")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Ögrencinin Bölümünü Seçmelisiniz")]
        public int DepartmanId { get; set; }
        
        [Required(ErrorMessage = "Hobbby Seçmelisiniz")]
        public int HobbyId { get; set; }
        
        [Required(ErrorMessage = "Sınıf Öğretmeni Seçmelisiniz")]
        public int TeacherId { get; set; }
        
        [Required(ErrorMessage = "Rehber Öğretmeni Seçmelisiniz")]
        public int GuidanceCounselorId { get; set; }

        public SelectList? Departmans { get; set; }

        public SelectList? Hobbies { get; set; }

        public SelectList? Teachers { get; set; }

        public SelectList? GuidanceCouncelors { get; set; }

    }


}
