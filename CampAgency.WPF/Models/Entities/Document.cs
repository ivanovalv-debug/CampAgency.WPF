using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities;

public partial class Document
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public int Type { get; set; }

    public string? FilePath { get; set; }

    public int Status { get; set; }

    public string? Comment { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
