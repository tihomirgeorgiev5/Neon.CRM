using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neon.CRM.WebApp.Data.Models;

namespace Neon.CRM.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Agent>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set;} = null!;

        public DbSet<VacationPackage> VacationPackages { get; set;} = null!;

        public DbSet<Booking> Bookings { get; set;} = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Additional model configuration can go here
            builder.Entity<VacationPackage>().HasData(
                new VacationPackage
                {
                    Id = 1,
                    Title = "Tropical Paradise",
                    Description = "Enjoy a week in a tropical paradise with white sandy beaches and crystal-clear waters.",
                    Price = 1999.99m,
                    DurationInDays = 7
                },
                new VacationPackage
                {
                    Id = 2,
                    Title = "Mountain Adventure",
                    Description = "Experience the thrill of mountain climbing and hiking in breathtaking landscapes.",
                    Price = 1499.99m,
                    DurationInDays = 5
                },
                new VacationPackage
                {
                    Id = 3,
                    Title = "Cultural Exploration",
                    Description = "Discover ancient cities, rich history, and vibrant cultures on this unforgettable journey.",
                    Price = 1799.99m,
                    DurationInDays = 6
                }
            );
        }
    }
}
