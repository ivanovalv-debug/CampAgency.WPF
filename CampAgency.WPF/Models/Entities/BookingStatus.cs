using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class BookingStatus
    {
        public int BookingStatusId { get; set; }
        public string BookingStatusName { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}