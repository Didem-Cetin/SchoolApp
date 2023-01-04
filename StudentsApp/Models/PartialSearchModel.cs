
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentsApp.Models
{
    public class PartialSearchModel
    {
        public string? Fullname { get; set; }
        public int? HobbyId { get; set; }
        public int? TeacherId { get; set; }


        public SelectList? Hobbies { get; set; }
        public SelectList? Teachers { get; set; }
    }

}
