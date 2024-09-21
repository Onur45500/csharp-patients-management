using Microsoft.EntityFrameworkCore;

namespace csharp_patients_management.Models
{
    public class PatientsDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public PatientsDbContext(DbContextOptions<PatientsDbContext> options)
            : base(options)
        {

        }
    }
}
