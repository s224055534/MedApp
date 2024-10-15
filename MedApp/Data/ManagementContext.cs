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
  
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Visit> Visit { get; set; }
        public DbSet<Notes> Notes { get; set; }
    }
}
