using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities;

public partial class Camp
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Type { get; set; }

    public string? Region { get; set; }

    public string? Address { get; set; }

    public double? Rating { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
}
