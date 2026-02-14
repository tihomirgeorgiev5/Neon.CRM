using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neon.CRM.WebApp.Data.Models;

namespace Neon.CRM.WebApp.Data;

    public class TenantDbContext : IdentityDbContext<Agent>
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<VacationPackage> VacationPackages { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

public class TenantDbContextFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantDbContextFactory(IHttpContextAccessor httpContextAccessor)
    {
        this._httpContextAccessor = httpContextAccessor;
    }
    public TenantDbContext Create()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        var connectionString = user.FindFirst("TenantConnectionString")?.Value;
        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new TenantDbContext(optionsBuilder.Options);
    }
    
}




