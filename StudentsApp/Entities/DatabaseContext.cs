using Microsoft.EntityFrameworkCore;

namespace StudentsApp.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<GuidanceCounselor> GuidanceCounselors { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }

        
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        
    }
}
