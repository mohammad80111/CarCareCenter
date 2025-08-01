using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarCenter.Models
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Roll> rolls { get; set; }
        
        public DbSet <Employee> Employees { get; set; } 

        public DbSet<CarSize> carSizes { get; set; }

        public DbSet<Employee> employees { get; set; }

        public DbSet<Booking> bookings { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roll>().HasData(
                new Roll { RollID = 1, RollName = "Dry Clean" },
                new Roll { RollID = 2, RollName = "Polishing" },
                new Roll { RollID = 3, RollName = "Car Wash" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, EmployeeName = "Mohammad Sawalha" },
                new Employee { EmployeeID = 2, EmployeeName = "Ayham Sawalha" },
                new Employee { EmployeeID = 3, EmployeeName = "Ahmed Sawalha" }
            );

            modelBuilder.Entity<CarSize>().HasData(
                new CarSize { CarSizeID = 1, CarSizeName = "Sedan-Car" },
                new CarSize { CarSizeID = 2, CarSizeName = "Mid-Car" },
                new CarSize { CarSizeID = 3, CarSizeName = "Big-Car" }
            );

            // ✅ ضروري لاستكمال إعدادات ASP.NET Identity
            base.OnModelCreating(modelBuilder);
        }


    }
}
