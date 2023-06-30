using Microsoft.EntityFrameworkCore;

namespace BigBangAssesmemtTwo.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
