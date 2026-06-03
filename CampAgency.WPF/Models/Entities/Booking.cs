using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int ChildId { get; set; }
        public int ShiftId { get; set; }
        public int BookingStatusId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Child Child { get; set; } = null!;
        public virtual Shift Shift { get; set; } = null!;
        public virtual BookingStatus BookingStatus { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}