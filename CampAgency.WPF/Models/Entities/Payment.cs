using System;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public int PaymentTypeId { get; set; }
        public int PaymentStatusId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Price { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual PaymentType PaymentType { get; set; } = null!;
        public virtual PaymentStatus PaymentStatus { get; set; } = null!;
    }
}