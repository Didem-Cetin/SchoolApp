
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentsApp.Models
{
    public class PartialCreateModel
    {
        public string Fullname { get; set; }
        public int DepartmanId { get; set; }
        public int HobbyId { get; set; }
        public int TeacherId { get; set; }
        public int GuidanceCounselorId { get; set; }

        public byte? FormType { get; set; } 

        public SelectList? Departmans { get; set; }
        public SelectList? Hobbies { get; set; }
        public SelectList? Teachers { get; set; }
        public SelectList? GuidanceCouncelors { get; set; }
    }
    enum WhichForm : byte { modalForm,pageForm}

}
