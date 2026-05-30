using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities;

public partial class Shift
{
    public int Id { get; set; }

    public int CampId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal Price { get; set; }

    public int TotalSeats { get; set; }

    public int AvailableSeats { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Camp Camp { get; set; } = null!;
}
