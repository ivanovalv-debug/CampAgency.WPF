using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class PaymentStatus
    {
        public int PaymentStatusId { get; set; }
        public string PaymentStatusName { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}