using MedApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MedApp.Data
{
    public class ManagementContext:DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext>options): base(options)
        {
            
        }
  
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Assistant> Assistant { get; set; }
        public DbSet<Patient> Patient { get; set; }
    }
}
