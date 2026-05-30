using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities;

public partial class Child
{
    public int Id { get; set; }

    public int ParentId { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public int Gender { get; set; }

    public string? MedicalNotes { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual User Parent { get; set; } = null!;
}
