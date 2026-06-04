using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Shift
    {
        public int ShiftId { get; set; }
        public int CampId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal Price { get; set; }

        public virtual Camp Camp { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}