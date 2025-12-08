using System.ComponentModel.DataAnnotations;

namespace Neon.CRM.WebApp.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int VacationPackageId { get; set; }
        public DateTime BookingDate { get; set; }

        [Display(Name = "Confirmed")]
        public bool IsConfirmed { get; set; }

        // Navigation properties
        public Customer? Customer { get; set; }

        [Display(Name = "Vacation Package")]
        public VacationPackage? VacationPackage { get; set; }
    }
}
