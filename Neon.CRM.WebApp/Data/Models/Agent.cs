using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Neon.CRM.WebApp.Data.Models
{
    public class Agent : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? TenantConnectionString { get; set; }

        // Navigation property

        public ICollection<Customer> Customers { get; set; } = [];

        [NotMapped]
        public string FullName => $"{FirstName} {SecondName}".Trim();

    }
}
