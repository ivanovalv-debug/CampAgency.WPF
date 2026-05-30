using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities;

public partial class Booking
{
    public int Id { get; set; }

    public int ChildId { get; set; }

    public int ShiftId { get; set; }

    public int Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Child Child { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual Shift Shift { get; set; } = null!;
}
